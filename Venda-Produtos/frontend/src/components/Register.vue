<template>
    <div class="register">
        <h2>Registrar</h2>
        <form @submit.prevent="required">
            <div>
                <label for="nome">Nome:</label>
                <input type="text" v-model="nome" required />
            </div>
            <div>
                <label for="sobrenome">Sobrenome:</label>
                <input type="text" v-model="sobrenome" required>
            </div>
            <div>
                <label for="email">Email:</label>
                <input type="email" v-model="email" required />
            </div>
            <div>
                <label for="cpf">CPF</label>
                <input type="text" v-model="cpf" required />
            </div>
            <div>
                <label for="password">Senha:</label>
                <input type="password" v-model="password" required />
            </div>
            <button type="submit">Registrar</button>
        </form>
    </div>
</template>