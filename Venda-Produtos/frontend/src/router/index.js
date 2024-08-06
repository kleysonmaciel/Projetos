import Vue from 'vue';
import VueRouter from 'vue-router';
import Home from '../views/Home.vue';
import Login from '../views/Lofin.vue';
import Register from '../views/Register.vue';
import Product from '../views/Product.vue';
import Sales from '../views/Sales.vue';
import ProductForm from '../components/ProductForm.vue';

Vue.use(VueRouter);

const routes = [
    {path: '/', name: 'Home', component: Home},
    {path: '/login', name: 'Login', component: Login},
    {path: '/register', name: 'Register', component: Register},
    {path: '/products', name: 'Product', component: Product},
    {path: '/sales', name: 'Sales', component: Sales},
    {path: '/product/new', name: 'NewProduct', component: ProductForm},
    {path: '/product/:id/edit', name: 'EditProduct', component: ProductForm}
];

const router = new VueRouter({
    mode: 'history',
    base: ProcessingInstruction.env.BASE_URL,
    routes
});

export default router;