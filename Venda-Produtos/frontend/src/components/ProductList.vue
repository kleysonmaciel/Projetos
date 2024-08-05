<template>
    <div>
        <h2>Lista de Produtos</h2>
        <table>
            <thead>
                <tr>
                    <th>Nome</th>
                    <th>Preço</th>
                    <th>Quantidade em Estoque</th>
                    <th>Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="produto in produtos" :key="produto_id">
                    <td>{{ produto.nome }}</td>
                    <td>{{ produto.preco }}</td>
                    <td>{{ produto.quantidade_estoque }}</td>
                    <td>
                        <button @click="editproduto(produto_id)">Editar</button>
                        <button @click="deleteproduto(produto_id)">Excluir</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import axios from 'axios';
export default{
    data(){
        return{
            produtos:[]
        };
    },
    mothods:{
        async fetchprodutos(){
            const response = await axios.get('/api/produto');
            this.produtos = response.data;
        },
        editproduto(produto_id){
            this.$router.push(`/produto/${produto_id}/edit`);
        },
        async deleteproduto(produto_id){
            if(confirm('Tem certeza que deseja excluir este produto?')){
                await axios.delete(`/api/produto/${produto_id}`);
                this.fetchprodutos();
            }
        }
    },
    async mounted(){
        this.fetchprodutos();
    }
};
</script>