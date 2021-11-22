import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { EnviosComponent } from './components/EnviosComponent';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/EnviosComponent' component={EnviosComponent} />
      </Layout>
    );
  }
}
