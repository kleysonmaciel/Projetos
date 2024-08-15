<template>
    <div class="products">
        <h2>Produtos</h2>
        <button @click="createProduct">Novo Produto</button>
        <table>
            <thead>
                <tr>
                    <th>Nome</th>
                    <th>Preço</th>
                    <th>Quantidade</th>
                    <th>Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="product in product" :key="product.id">
                    <td>{{ product.nome }}</td>
                    <td>{{ product.preco }}</td>
                    <td>{{ product.quantidade_estoque }}</td>
                    <td>
                        <button @click="editProduct(product.id)">Editar</button>
                        <button @click="deleteProduct(product.id)">Excluir</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import {mapState, mapActions} from 'vuex';

export default{
    name: "Product",
    computed: {
        ...mapState(['products'])
    },
    created(){
        this.fetchProducts();
    },
    methods:{
        ...mapActions(['fetchProducts']),
        createProduct(){
            this.$router.push('/product/new');
        },
        editProduct(id){
            this.$router.push(`/product/${id}/edit`);
        },
        async deleteProduct(id){
            if(confirm('Você tem certeza que deseja excluir este produto?')){
                await axios.delete(`/api/produto/${id}`);
                this.fetchProducts();
            }
        }
    }
};
</script>

<style scoped>
.products{
    padding: 20px;
}
.products h2{
    margin-bottom: 20px;
}
.products table{
    width: 100%;
    border-collapse: collapse;
}
.products th, .products td{
    border: 1px solid #ccc;
    padding: 10px;
    text-align: left;
}
.products button{
    margin-right: 10px;
    padding: 5px 10px;
    background-color: #42b983;
    border: none;
    color: white;
    cursor: pointer;
}
.products button:hover{
    background-color: #379f76;
}
</style>