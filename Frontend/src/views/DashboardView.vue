<script setup lang="ts">
import { ref, onMounted } from 'vue';
import apiClient from '@/api/index.js' // 引入你剛寫好的 apiClient

// 定義資料介面 (對應後端的 DTO)
interface Project {
  id: number;
  name: string;
  description: string;
  category: string;
}

// 1. 建立響應式變數，預設為空陣列
const projects = ref<Project[]>([]);
const loading = ref(true);
const error = ref('');

// 2. 定義抓取資料的函式
const fetchProjects = async () => {
  try { 
    const response = await apiClient.get('/api/projects')
    // .NET 預設回傳的 JSON 屬性通常是 camelCase (首字小寫)
    // 但如果後端沒設定，可能是 PascalCase (首字大寫)。
    // 建議先 console.log(response.data) 確認一下
    projects.value = response.data;
    console.log('資料獲取成功:', projects.value);
  } catch (err) {
    console.error('API 錯誤:', err);
    error.value = '無法載入專案列表，請確認後端是否已啟動。';
  } finally {
    loading.value = false;
  }
};

// 3. 在組件掛載時執行
onMounted(() => {
  fetchProjects();
});
</script>

<template>
  <div class="p-6">
    <h1 class="text-3xl font-bold mb-6">我的專案儀表板</h1>

    <div v-if="loading" class="text-gray-500">資料載入中...</div>

    <div v-if="error" class="text-red-500 mb-4">{{ error }}</div>

    <div v-else class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
      
      <div 
        v-for="item in projects" 
        :key="item.id" 
        class="bg-white rounded-xl shadow-md p-6 hover:shadow-lg transition-shadow border border-gray-100"
      >
        <div class="flex justify-between items-start mb-4">
          <h2 class="text-xl font-semibold text-gray-800">{{ item.name }}</h2>
          <span class="px-2 py-1 text-xs font-medium bg-blue-100 text-blue-800 rounded-full">
            {{ item.category }}
          </span>
        </div>
        <p class="text-gray-600 mb-4">{{ item.description }}</p>
        <button class="text-blue-600 hover:text-blue-800 text-sm font-medium">
          查看詳情 &rarr;
        </button>
      </div>

    </div>
  </div>
</template>