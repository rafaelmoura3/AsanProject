import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import ProblemsList from '../views/problems/ProblemsList.vue'
import ProblemsCrud from '../views/problems/ProblemsCrud.vue'
import PartsCrud from '../views/parts/PartsCrud.vue'
import PartsList from '../views/parts/PartsList.vue'
import SpaceShipTypeCrud from '../views/spaceshiptype/SpaceShipTypeCrud.vue'
import SpaceShipTypeList from '../views/spaceshiptype/SpaceShipTypeList.vue'
import SpaceShipCrud from '../views/spaceship/SpaceShipCrud.vue'
import SpaceShipList from '../views/spaceship/SpaceShipList.vue'
import ToolsCrud from '../views/tools/ToolsCrud.vue'
import ToolsList from '../views/tools/ToolsList.vue'
import Maintenance from '../views/maintenancespaceship/MaintenanceSpaceShip.vue'
import ToolPerPartCrud from '../views/toolperpart/ToolPerPartCrud.vue'
import ToolPerPartList from '../views/toolperpart/ToolPerPartList.vue'
import Management from '../views/management/Management.vue'
import Report from '../views/report/Report.vue'
Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/problems',
    name: 'problemsList',
    component: ProblemsList
  },
  {
    path: '/problems/create',
    name: 'problemsCreate',
    component: ProblemsCrud
  },
  {
    path: '/problems/:id/edit',
    name: 'problemsEdit',
    component: ProblemsCrud
  },
  {
    path: '/problems/:id',
    name: 'problemsRead',
    component: ProblemsCrud
  },
  {
    path: '/ships/create',
    name: 'shipsCreate',
    component: SpaceShipCrud
  },
  {
    path: '/ships/:id/edit',
    name: 'shipsEdit',
    component: SpaceShipCrud
  },
  {
    path: '/parts/create',
    name: 'partsCreate',
    component: PartsCrud
  },
  {
    path: '/parts/:id/edit',
    name: 'partsEdit',
    component: PartsCrud
  },
  {
    path: '/parts',
    name: 'partsList',
    component: PartsList
  },
  {
    path: '/parts/:id',
    name: 'partsRead',
    component: PartsCrud
  },
  {
    path: '/spaceshiptype/create',
    name: 'spaceshiptypeCreate',
    component: SpaceShipTypeCrud
  },
  {
    path: '/spaceshiptype/:id/edit',
    name: 'spaceshiptypeEdit',
    component: SpaceShipTypeCrud
  },
  {
    path: '/spaceshiptype',
    name: 'spaceshiptypeList',
    component: SpaceShipTypeList
  },
  {
    path: '/spaceshiptype/:id',
    name: 'spaceshiptypeRead',
    component: SpaceShipTypeCrud
  },
  {
    path: '/ships',
    name: 'shipsList',
    component: SpaceShipList
  },
  {
    path: '/tools/create',
    name: 'toolsCreate',
    component: ToolsCrud
  },
  {
    path: '/tools/:id',
    name: 'toolsRead',
    component: ToolsCrud
  },
  {
    path: '/tools/:id/edit',
    name: 'toolsEdit',
    component: ToolsCrud
  },
  {
    path: '/tools',
    name: 'toolsList',
    component: ToolsList
  },
  {
    path: '/maintenances/repair/:id',
    name: 'maintenance',
    component: Maintenance
  },
  {
    path: '/toolperpart/create',
    name: 'toolPerPartCreate',
    component: ToolPerPartCrud
  },
  {
    path: '/toolperpart/:id',
    name: 'toolPerPartRead',
    component: ToolPerPartCrud
  },
  {
    path: '/toolperpart/:id/edit',
    name: 'toolPerPartEdit',
    component: ToolPerPartCrud
  },
  {
    path: '/toolperpart',
    name: 'toolPerPartList',
    component: ToolPerPartList
  },
  {
    path: '/management',
    name: 'management',
    component: Management
  },
  {
    path: '/report',
    name: 'report',
    component: Report
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
