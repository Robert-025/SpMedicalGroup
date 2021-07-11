import React, { Component } from 'react';
import { StyleSheet, Text, View, TouchableOpacity, Image, TextInput } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component{
  constructor(props){
    super(props);
    this.state = {
      email : '',
      senha : ''
    }
  }

  realizarLogin = async () => {

    try {
      //Armazena a resposta da API e passa o email e senha
      const resposta = await api.post('/Login', {
        email : this.state.email,
        senha : this.state.senha
      });

      //Pega o token pela resposta da API 
      const token = resposta.data.token

      //Armazena no asyncStorage o token recebido na constante acima
      await AsyncStorage.setItem('token', token)
      
      if (resposta.status === 200) {
        this.props.navigation.navigate('Main')
      }
    
    } 
    catch (Exception) {
      console.warn(Exception)
    }
  }
  
  render(){
    return(
      <View style={styles.main}>
        <View style={styles.logoMain}>
          <Image 
            source={require('../../assets/img/Logo.png')}
            style={styles.logoLogin}
          />
          <Text style={styles.tituloLogo}>SP Medical Group</Text>
        </View>
        <View style={styles.infoBarras}>

          <TextInput 
            style={styles.inputLogin}
            placeholder='E-mail'
            placeholderTextColor='#808080'
            keyboardType='email-address'
            color='#000'
            onChangeText={ email => this.setState({ email })}
          />

          <TextInput 
            style={styles.inputLogin}
            placeholder='Senha'
            placeholderTextColor='#808080'
            //Para aparecer aquelas bolinhas no campo de seha
            secureTextEntry={true}
            color='#000'
            onChangeText={ senha => this.setState({ senha })}
          />

          <TouchableOpacity 
            style={styles.btnLogin}
            onPress={this.realizarLogin}
          >
            <Text style={styles.textoBtn}>Login</Text>
          </TouchableOpacity>

        </View>
      </View>
    )
  }
}

const styles = StyleSheet.create({
  //Tela inteira
  main: {
    flex: 1,
    backgroundColor: '#005AE6',
    alignItems: 'center',
    justifyContent: 'center',
  },

  logoMain: {
    flex: 2,
    alignItems: 'center',
    justifyContent: 'center'
  },

  logoLogin: {
    width: 150,
    height: 162,
    marginBottom: 30
  },

  tituloLogo: {
    fontSize: 28,
    color: '#fff',
  },

  btnLogin: {
    width: 150,
    height: 40,
    backgroundColor: '#fff',
    borderRadius: 20,
    borderWidth: 1,
    shadowOffset: { height: 2, width: 2 },
    borderColor: '#ccc',
    alignItems: 'center',
    justifyContent: 'center'
  },

  infoBarras: {
    flex: 2,
    alignItems: 'center',
    justifyContent: "space-around",
    marginBottom: 130
  },
  
  textoBtn: {
    color: '#000',
    fontSize: 20,
  },

  inputLogin: {
    backgroundColor: '#fff',
    width: 250,
    height: 40,
    borderRadius: 20,
  }
});