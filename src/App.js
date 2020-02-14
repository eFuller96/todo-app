import React from 'react';
import {
  Header, Container, Form,
  Button, Divider, Grid
} from 'semantic-ui-react'
import './App.css';

const App = (() => {
  return <Container className='page'>
    <Header className='app-header'>Todo App</Header>
    <Divider />
    <Grid className='content'>
      <Container className='add-item'>
        <Form>
          <Form.Field>
            <label>Item Name</label>
            <input placeholder='Item Name' />
          </Form.Field>
          <Button type='submit'>Add</Button>
        </Form>
      </Container>
    </Grid>
  </Container>
})

export default App;
