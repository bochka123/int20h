FROM node:18.15.0-alpine3.17 as builder
COPY package.json package-lock.json ./
RUN npm i && mkdir /client && mv ./node_modules ./client
WORKDIR /client
COPY . .
RUN npm run build

FROM nginx:1.21.1-alpine
COPY nginx.conf /etc/nginx/nginx.conf
RUN rm -rf /usr/share/nginx/html/*
COPY --from=builder /client/dist/* /usr/share/nginx/html
EXPOSE 80 443
ENTRYPOINT ["nginx", "-g", "daemon off;"]
