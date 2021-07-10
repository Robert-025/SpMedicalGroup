import React, { Component } from 'react';
import { StyleSheet, Text, View } from 'react-native';

import api from '../services/api';

export default class Perfil extends Component{
  
  render(){
    return(
      <View style={styles.main}>
        <Text>Perfil</Text>
      </View>
    )
  }
}

const styles = StyleSheet.create({
  //Tela inteira
  main: {
    flex: 1,
    backgroundColor: '#cccccc',
  },
});