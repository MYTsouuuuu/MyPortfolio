import axios from 'axios';

// 檢查變數是否有讀到
console.log('目前的 API 網址是:', import.meta.env.VITE_API_URL);

// 這裡讀取你之前在 .env.development 設定的 VITE_API_URL
const apiClient = axios.create({
  baseURL: import.meta.env.VITE_API_URL,
  headers: {
    'Content-Type': 'application/json'
  }
});

export default apiClient;