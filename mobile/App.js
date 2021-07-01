import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View } from 'react-native';

import api from './src/services/api';

export default class App extends Component() {
  constructor(props){
    super(props);
    this.state = {
      listaConsultas : []
    };
  }
  
  buscarConsultas = () => {
    const resposta = await api.get('Consulta/minhas')
  
    this.setState({ listaConsultas : resposta.data })
  };
  
  componentDidMount(){
    this.buscarConsultas();
  }

  render() {
    return(
      <View></View>
    )
  }

}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
