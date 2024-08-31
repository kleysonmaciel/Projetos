import React, { useState } from 'react';
import axios from 'axios';
import '../styles/ClienteForm.css';

function ClienteForm() {
    const [cliente, setCliente] = useState({
        nome: '',
        sobrenome: '',
        email: '',
        cpf: '',
        endereco: '',
        cep: ''
    });
    const handleChange = (e) => {
        setCliente({
            ...cliente,
            [e.target.name]: e.target.value
        });
    };
    const handleSubmit = (e) => {
        e.preventDefault();
        axios.post('api/cliente', cliente)
            .then(() => {
                setCliente({
                    nome: '',
                    sobrenome: '',
                    email: '',
                    cpf: '',
                    endereco: '',
                    cep: ''
                });
            })
            .catch(err => {
                setError('Erro ao cadastrar o cliente.');
            });
    };
    if (error) return <p>{error}</p>
    return (
        <form onSubmit={handleSubmit} className="form-container">
            <h2>Cadastrar Cliente</h2>
            <input
                name="nome"
                value={cliente.nome}
                onChange={handleChange}
                placeholder="Nome"
                required
            />
            <input
                name="sobrenome"
                value={cliente.sobrenome}
                onChange={handleChange}
                placeholder="Sobrenome"
                required
            />
            <input
                name="email"
                type="email"
                value={cliente.email}
                onChange={handleChange}
                placeholder="Email"
                required
            />
            <input
                name="cpf"
                value={cliente.cpf}
                onChange={handleChange}
                placeholder="CPF"
                required
            />
            <input
                name="endereco"
                value={cliente.endereco}
                onChange={handleChange}
                placeholder="Endereço"
            />
            <input
                name="cep"
                value={cliente.cep}
                onChange={handleChange}
                placeholder="CEP"
            />
            <button type="submit">Cadastrar</button>
        </form>
    );
}
export default ClienteForm;