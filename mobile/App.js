import React, { Component } from 'react';
import { StyleSheet, Text, View } from 'react-native';

export default class App extends Component{

  render(){
    return(
      <View style={styles.main}>
        <Text>HomePage</Text>
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