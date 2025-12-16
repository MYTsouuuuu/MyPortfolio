<template>
  <header class="w-full bg-white/80 dark:bg-slate-900/80 backdrop-blur border-b border-gray-200 dark:border-slate-700">
    <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
      <div class="h-16 flex items-center justify-between">
        <div class="flex items-center gap-4">
          <!-- Mobile sidebar toggle -->
          <button @click="$emit('toggle-sidebar')" class="lg:hidden p-2 rounded-md hover:bg-gray-100 dark:hover:bg-slate-800">
            <svg class="w-6 h-6 text-gray-700 dark:text-gray-200" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16"/></svg>
          </button>

          <div class="block lg:hidden font-bold text-lg text-gray-900 dark:text-white">MytFolio</div>
        </div>

        <div class="flex items-center gap-4">
          <div class="hidden sm:block text-sm text-gray-600 dark:text-gray-300">歡迎回來</div>
          <button class="px-3 py-1 rounded-md bg-sky-100 dark:bg-slate-800 text-sky-700 dark:text-sky-300 text-sm">新增</button>
        </div>
      </div>
    </div>
  </header>
</template>

<script setup>
// emits toggle-sidebar
</script>
