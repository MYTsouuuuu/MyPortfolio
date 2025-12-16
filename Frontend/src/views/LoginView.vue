<template>
  <div class="min-h-screen flex items-center justify-center p-8 bg-linear-to-br from-sky-50 via-indigo-50 to-transparent">
    <div class="w-full max-w-md bg-white/95 dark:bg-slate-900/90 rounded-xl shadow-lg border border-gray-200 dark:border-slate-700 p-8">
      <h1 class="text-2xl font-semibold text-gray-900 dark:text-white mb-4">登入</h1>
      <form @submit.prevent="onSubmit" class="space-y-4">
        <div>
          <label class="block text-sm text-gray-600 dark:text-gray-300">Email</label>
          <input v-model="email" type="email" required placeholder="you@example.com"
            class="mt-1 w-full px-4 py-2 rounded-lg border border-gray-300 dark:border-slate-600 bg-white dark:bg-slate-800 text-gray-900 dark:text-gray-100 focus:outline-none focus:ring-2 focus:ring-sky-300" />
        </div>

        <div>
          <label class="block text-sm text-gray-600 dark:text-gray-300">Password</label>
          <input v-model="password" type="password" required placeholder="Password"
            class="mt-1 w-full px-4 py-2 rounded-lg border border-gray-300 dark:border-slate-600 bg-white dark:bg-slate-800 text-gray-900 dark:text-gray-100 focus:outline-none focus:ring-2 focus:ring-sky-300" />
        </div>

        <button class="mt-4 w-full py-3 rounded-lg bg-linear-to-r from-sky-500 to-indigo-500 text-white font-semibold hover:opacity-95 active:translate-y-px"
          type="submit">登入</button>
      </form>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const email = ref('')
const password = ref('')
const router = useRouter()

function onSubmit() {
  // Mock login: accept any input and navigate to dashboard
  console.log('Mock login', email.value, password.value)
  router.push('/dashboard')
}
</script>
