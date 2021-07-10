import React, { Component } from 'react';
import { StyleSheet, Text, View, Image } from 'react-native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

import Consultas from './consultas';
import Login from './login';
import Perfil from './perfil';

const bottomTab = createBottomTabNavigator();

export default class Main extends Component{

  render(){
    return(
      <View style={styles.main}>
        <bottomTab.Navigator
        initialRouteName='Consultas'
        tabBarOptions= {{
        showLabel : true,
        activeBackgroundColor : '#ccc',
        inactiveBackgroundColor : '#fff',
        activeTintColor: '000',
        inactiveTintColor: '000',
        style : { height : 50 }
        }}
        screenOptions = { ({ route }) => ({
        tabBarIcon : () => {
            if (route.name === "Perfil") {
            return (
                <Image 
                source={require('../../assets/img/perfil-de-usuario.png')}
                style={styles.tabBarIcon}
                />
            )
            }

            if (route.name === "Consultas") {
            return (
                <Image 
                source={require('../../assets/img/Lista.png')}
                style={styles.tabBarIcon}
                />
            )
            }
        }
        }) }
        >
        <bottomTab.Screen name='Consultas' component={Consultas}/>
        <bottomTab.Screen name='Perfil' component={Perfil}/>
        </bottomTab.Navigator>
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

  tabBarIcon: {
    width: 30,
    height: 30,
    tintColor: '000'
  }
});