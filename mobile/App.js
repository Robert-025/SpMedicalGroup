import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View } from 'react-native';

import api from './src/services/api';

export default class App extends Component{
  constructor(props){
    super(props);
    this.state = {
      listaConsultas: [],
    }
  }

  buscarConsultas = async () => {
    //Faz a requisição para a API 
    const resposta = await api.get("/Consulta");

    //Armazena a resposta da API
    const dadosApi = resposta.data;

    //Atualiza a listaConsultas
    this.setState({ listaConsultas: dadosApi })
  }

  //Realiza a função assim que entrar na DOM
  componentDidMount(){
    this.buscarConsultas();
  }

  render(){
    return(
      <View style={styles.main}>

        {/* MAIN */}

        <View style={styles.cabecalho}>
          <Text style={styles.tituloCabecalho}>{"Consultas".toUpperCase()}</Text>
        </View>

        <View>

        </View>

      {/*  */}

      </View>
    )
  }
}

const styles = StyleSheet.create({
  main: {
    flex: 1,
    backgroundColor: '#005ae6',
    alignItems: 'center',
    justifyContent: 'center',
  },

  cabecalho: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center'
  },

  tituloCabecalho: {
    fontSize: 20,
    justifyContent: 'center',
    alignItems: 'center',
    color: '#fff',
  }
});