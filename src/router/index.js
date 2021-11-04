import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: () => import('../views//home-page/index.vue')
  },
  {
    path: '/menu',
    name: 'Menu',
    component: () => import('../views/menu/MenuList.vue')
  },
  {
    path: '/employee',
    name: 'Employee',
    component: () => import('../views/employee/EmployeeList.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
