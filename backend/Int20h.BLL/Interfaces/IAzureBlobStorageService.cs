using Int20h.Common.Dtos.File;

namespace Int20h.BLL.Interfaces;

public interface IAzureBlobStorageService
{
    Task<FileDto> AddFileToBlobStorage(NewFileDto newFileDto);
    Task DeleteFromBlob(FileDto fileDto);
}
