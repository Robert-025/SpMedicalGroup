import React, { Component } from 'react';
import { StyleSheet, Text, View } from 'react-native';

import api from './src/services/api';

export default class App extends Component{
  
  render(){
    return(
      <View style={styles.main}>
        <Text>Login</Text>
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