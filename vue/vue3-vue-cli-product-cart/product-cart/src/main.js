import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

// createApp(App).use(router).mount('#app')

// or
import './assets/styles/style.scss'
const app = createApp(App)
app.use(router)
app.mount('#app')
