import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import '../styles/ClienteList.css';


function ClienteList() {

    const [loading, setLoading] = useState(true);

    const [error, setError] = useState(null);

    useEffect(() => {
        fetchClientes();
    }, []);

    const fetchClientes = () => {
        axios.get('/api/cliente')
            .then(response => {
                setClientes(response.data);
            })
            .catch(err => {
                setError('Erro ao buscar clientes');
            });
    };

    const deleteCliente = (id) => {
        axios.delete(`/api/cliente/${id}`)
            .then(() => {
                setClientes(clientes.filter(cliente => cliente.id !== id));
            })
            .catch(err => {
                setError('Erro ao deletar cliente.');
            });
    };

    if (error) return <p>{Error}</p>;

    return (
        <div>
            <h2>Lista de Clientes</h2>
            <ul className="cliente-list">
                {clientes.map(cliente => (
                    <li key={cliente.id} className="cliente-item">
                        {cliente.nome} {cliente.sobrenome} - {cliente.email}
                        <div>
                            <button onClick={() => deleteCliente(cliente.id)}>Excluir</button>
                            <button onClick={() => editCliente(cliente.id)}>Editar</button>
                        </div>
                    </li>
                ))}
            </ul>
        </div>
    );
}
export default ClienteList;