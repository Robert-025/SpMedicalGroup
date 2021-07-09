import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View } from 'react-native';

import api from '../services/api';

export default class Consultas extends Component{
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

        {/* Cabeçalho */}

        <View style={styles.cabecalho}>
          <Text style={styles.textoCabecalho}>{"Consultas".toUpperCase()}</Text>
        </View>

        {/* CORPO */}

        <View style={styles.corpo}>
          <FlatList 
            contentContainerStyle={styles.corpoContent}
            data={this.state.listaConsultas}
            keyExtractor={ item => item.idConsulta }
            renderItem={this.renderItem}
          />
        </View>
      </View>
    )
  }

  renderItem = ({ item }) => (
    <View style={styles.flatItemContainer}>
      <View style={styles.flatItemLinha}>
        <View style={styles.flatItemPerfil}>
          <Image 
            source={require('../../assets/img/perfil-de-usuario.png')}
            style={styles.flatItemIcon}
          />
          <Text style={styles.flatItemTextoPerfil} >{item.idPacienteNavigation.idUsuarioNavigation.nome}</Text>
        </View>
        <View style={styles.flatItemData}>
          <Image 
              source={require('../../assets/img/calendar.png')}
              style={styles.flatItemIcon}
            />
          <Text style={styles.flatItemTextoData}>{Intl.DateTimeFormat('pt-BR').format(new Date(item.dataConsulta))}-{(item.dataConsulta).split('T')[1]}</Text>
        </View>
        <View style={styles.flatItemDescricao}>
          <Image 
            source={require('../../assets/img/hastag.png')}
            style={styles.flatItemIcon}
          />
          <Text style={styles.flatItemTextoDescricao}>{item.descricao}</Text>
        </View>
        <View style={styles.flatItemSituacao}>
          <Text style={styles.flatItemTextoSituacao}>{item.idSituacaoNavigation.descricao}</Text>
        </View>
      </View>
    </View>
  )
}

const styles = StyleSheet.create({
  //Tela inteira
  main: {
    flex: 1,
    backgroundColor: '#005ae6',
  },

  cabecalho: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
  },

  textoCabecalho: {
    color: '#fff',
    fontSize: 20
  },

  corpo: {
    flex: 5,
    alignItems: 'center',
    justifyContent: 'center'
    // backgroundColor: '#f0f0f0'
  },

  //Dentro da lista
  corpoContent: {
    paddingLeft: 40,
    paddingRight: 40,
    justifyContent: 'center',
    alignItems: 'center'
  },

  flatItemContainer: {
    flexDirection: 'row',
    marginTop: 30,
    paddingRight: 25,
    paddingLeft: 25,
    paddingTop: 10,
    paddingBottom: 10,
    backgroundColor: '#fff',
    borderRadius: 25,
  },

  flatItemLinha: {
    flex: 1,
    flexDirection: 'column',
    alignItems: 'flex-start',
    justifyContent: 'space-around',
  },

  flatItemPerfil: {
    fontSize: 12,
    color: '#000',
    flexDirection: 'row'
  },
  
  flatItemData: {
    fontSize: 12,
    color: '#000',
    flexDirection: 'row'
  },

  flatItemDescricao: {
    fontSize: 12,
    color: '#000',
    flexDirection: 'row',
  },
  
  flatItemSituacao: {
    fontSize: 12,
    color: '#000',
    flexDirection: 'row'
  },

  flatItemTextoPerfil: {
    marginTop: 7,
    marginLeft: 5
  },

  flatItemTextoData: {
    marginTop: 7,
    marginLeft: 5
  },

  flatItemTextoDescricao: {
    marginTop: 7,
    marginLeft: 5
  },

  flatItemTextoSituacao: {
    marginLeft: 50
  },

  flatItemIcon: {
    marginRigth: 50,
    width: 20,
    height: 20,
    marginTop: 7
  }
});