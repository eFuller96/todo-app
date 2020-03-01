import React, { useState } from 'react';
import {
  Header, Container, Form,
  Button, Divider, Grid,
  Input, List
} from 'semantic-ui-react'
import './App.css';

const App = (() => {
  const [itemToAdd, setItemToAdd] = useState('')
  const [itemList, setItemList] = useState([])

  const handleOnSubmit = () => {
    var newItemList = [...itemList, itemToAdd]
    setItemList(newItemList)
    setItemToAdd('')
  }

  const handleOnChange = (e) => {
    setItemToAdd(e.target.value)
  }

  return <Container className='page'>
    <Header className='app-header'>Todo App</Header>
    <Divider />
    <Grid className='content'>
      <Grid.Row>
        <Grid.Column>
          <Container className='add-item'>
            <Form>
              <Form.Field>
                <label>To Do:</label>
                <Input placeholder='To do' value={itemToAdd} onChange={handleOnChange} />
              </Form.Field>
              <Button disabled={itemToAdd === ''} type='submit' onClick={handleOnSubmit}>Add</Button>
            </Form>
          </Container>
        </Grid.Column>
        <Grid.Column>
          <Container className='items-list'>
            <List items={itemList} />
          </Container>
        </Grid.Column>
      </Grid.Row>
    </Grid>
  </Container>
})

export default App;
