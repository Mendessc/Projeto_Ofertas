import { Component } from 'react';
import { useState, useEffect } from 'react';
import axios, { Axios } from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { Link } from 'react-router-dom';
import { render } from '@testing-library/react';

export default function Home() {
    const [listaProdutos, setListaProdutos] = useState([]);
    return (
        <div>
            <h1>TESTE</h1>
        </div>
    );
}