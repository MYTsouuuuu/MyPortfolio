<template>
  <!-- Desktop sidebar: visible on lg and up -->
  <aside class="hidden lg:block lg:fixed lg:inset-y-0 lg:left-0 lg:w-64 bg-white dark:bg-slate-900 border-r border-gray-200 dark:border-slate-700 p-4">
    <div class="h-full flex flex-col">
      <div class="mb-6 px-2">
        <div class="text-lg font-bold text-gray-900 dark:text-white">MytFolio</div>
        <div class="text-xs text-gray-500 dark:text-gray-400">Dashboard</div>
      </div>

      <nav class="flex-1">
        <ul class="space-y-1">
          <li>
            <a href="#" class="block px-3 py-2 rounded-md text-sm text-gray-700 dark:text-gray-200 hover:bg-gray-100 dark:hover:bg-slate-800">概覽</a>
          </li>
          <li>
            <a href="#" class="block px-3 py-2 rounded-md text-sm text-gray-700 dark:text-gray-200 hover:bg-gray-100 dark:hover:bg-slate-800">報表</a>
          </li>
          <li>
            <a href="#" class="block px-3 py-2 rounded-md text-sm text-gray-700 dark:text-gray-200 hover:bg-gray-100 dark:hover:bg-slate-800">設定</a>
          </li>
        </ul>
      </nav>

      <div class="mt-auto px-2 text-sm text-gray-500 dark:text-gray-400">
        © 2025
      </div>
    </div>
  </aside>

  <!-- Mobile drawer: shown when mobileOpen prop is true -->
  <transition name="fade">
    <div v-if="mobileOpen" class="lg:hidden fixed inset-0 z-40">
      <div class="absolute inset-0 bg-black/40" @click="close"></div>
      <aside class="absolute left-0 top-0 h-full w-72 bg-white dark:bg-slate-900 p-4 shadow-lg">
        <div class="mb-6">
          <div class="text-lg font-bold text-gray-900 dark:text-white">MytFolio</div>
          <button class="mt-2 text-sm text-gray-500" @click="close">關閉</button>
        </div>
        <nav>
          <ul class="space-y-2">
            <li><a href="#" class="block px-3 py-2 rounded-md text-sm text-gray-700 dark:text-gray-200">概覽</a></li>
            <li><a href="#" class="block px-3 py-2 rounded-md text-sm text-gray-700 dark:text-gray-200">報表</a></li>
            <li><a href="#" class="block px-3 py-2 rounded-md text-sm text-gray-700 dark:text-gray-200">設定</a></li>
          </ul>
        </nav>
      </aside>
    </div>
  </transition>
</template>

<script setup>
import { defineProps, defineEmits } from 'vue'

const props = defineProps({
  mobileOpen: { type: Boolean, default: false },
})

const emits = defineEmits(['close'])

function close() {
  emits('close')
}
</script>
