<template>
  <div class="bg-white dark:bg-slate-900 border border-gray-200 dark:border-slate-700 rounded-lg p-4 shadow-sm">
    <div class="flex items-start justify-between">
      <div>
        <div class="text-sm text-gray-500 dark:text-gray-400">{{ title }}</div>
        <div class="text-2xl font-semibold text-gray-900 dark:text-white">{{ value }}</div>
      </div>
      <div class="text-sm text-gray-400">{{ meta }}</div>
    </div>
    <div class="mt-3">
      <slot />
    </div>
  </div>
</template>

<script setup>
import { defineProps } from 'vue'

const props = defineProps({
  title: { type: String, default: '' },
  value: { type: [String, Number], default: '' },
  meta: { type: String, default: '' },
})
</script>
