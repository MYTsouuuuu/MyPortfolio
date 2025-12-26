# --- 第一階段：建置 ---
FROM node:22-alpine AS build-stage
WORKDIR /app

# 1. 接收 docker-compose 傳來的參數
ARG VITE_API_URL

# 2. 將參數轉為環境變數 (讓 npm run build 看得見)
ENV VITE_API_URL=https://sjxfh9f6pm.ap-northeast-1.awsapprunner.com

COPY package*.json ./
RUN npm install

COPY . .

# 3. 開始打包 (這時候 Vite 就能讀到上面的 ENV 了)
RUN npm run build

# --- 第二階段：執行 ---
FROM nginx:stable-alpine AS production-stage
COPY --from=build-stage /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]