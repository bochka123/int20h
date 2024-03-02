using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Int20h.BLL.Interfaces;
using Int20h.BLL.Services.Abstract;
using Int20h.Common.Dtos.File;
using Int20h.Common.Helpers;
using Int20h.DAL.Context;
using Microsoft.AspNetCore.StaticFiles;

namespace Int20h.BLL.Services;

public class AzureBlobStorageService : BaseService, IAzureBlobStorageService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly BlobContainerOptionsHelper _blobContainerOptionsHelper;

    public AzureBlobStorageService(
        ApplicationDbContext context,
        IMapper mapper,
        BlobContainerOptionsHelper blobContainerOptionsHelper,
        BlobServiceClient blobServiceClient) : base(context, mapper)
    {
        _blobServiceClient = blobServiceClient;
        _blobContainerOptionsHelper = blobContainerOptionsHelper;
    }

    public async Task<FileDto> AddFileToBlobStorage(NewFileDto newFileDto)
    {
        if (newFileDto.Stream == null)
        {
            throw new ArgumentNullException($"{newFileDto.FileName} is empty");
        }

        await CreateDirectory(_blobContainerOptionsHelper.BlobContainerName);

        var uniqueFileName = CreateName(newFileDto.FileName, _blobContainerOptionsHelper.BlobContainerName);

        var provider = new FileExtensionContentTypeProvider();

        if (!provider.TryGetContentType(newFileDto.FileName, out string contentType))
        {
            throw new ArgumentNullException($"{newFileDto.FileName} can not get content type");
        }

        var blob = _blobServiceClient.GetBlobContainerClient(_blobContainerOptionsHelper.BlobContainerName)
                .GetBlobClient(uniqueFileName);

        var blobHttpHeaders = new BlobHttpHeaders();
        blobHttpHeaders.ContentType = contentType;

        await blob.UploadAsync(newFileDto.Stream, blobHttpHeaders);

        var uploadFile = new FileDto()
        {
            Url = blob.Uri.AbsoluteUri
        };

        return uploadFile;
    }

    public async Task DeleteFromBlob(FileDto file)
    {
        var fileName = Path.GetFileName(file.Url);
        var blob = _blobServiceClient.GetBlobContainerClient(_blobContainerOptionsHelper.BlobContainerName)
            .GetBlobClient(fileName);
        await blob.DeleteIfExistsAsync();
    }

    private async Task CreateDirectory(string folderPath)
    {
        if (!_blobServiceClient.GetBlobContainerClient(folderPath).Exists())
        {
            await _blobServiceClient.CreateBlobContainerAsync(folderPath);
        }
    }


    private string CreateName(string fileName, string folderPath)
    {
        var blob = _blobServiceClient.GetBlobContainerClient(folderPath).GetBlobClient(fileName);

        if (blob.Exists())
        {
            return $"{Path.GetFileNameWithoutExtension(fileName)}_" +
                $"{Guid.NewGuid()}" +
                $"{Path.GetExtension(fileName)}";
        }

        return fileName;
    }
}
