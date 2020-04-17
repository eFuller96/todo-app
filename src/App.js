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

  const removeItem = (indexToRemove) => {
    var updatedItemList = [...itemList]
    updatedItemList.splice(indexToRemove, 1)
    setItemList(updatedItemList)
  }

  return <Container className='page'>
    <Header className='app-header'>Todo App</Header>
    <Divider />
    <Grid columns={3}>
      <Grid.Row>
        <Grid.Column width={1} className='add-item'>
          <Form>
            <Form.Field>
              <Input placeholder='To do' value={itemToAdd} onChange={handleOnChange} />
            </Form.Field>
            <Button disabled={itemToAdd === ''} type='submit' onClick={handleOnSubmit}>Add</Button>
          </Form>
        </Grid.Column>
        <Grid.Column width={2} className='items-list'>
          <label>To Do:</label>
          <List className='inner-items-list'>
            {itemList.map((item, index) => {
              return <List.Item key={index + "-" + item}>
                <div onClick={() => removeItem(index)} className='remove-icon'>x</div>
                <List.Content>{item}</List.Content>
              </List.Item>
            })}
          </List>
        </Grid.Column>
      </Grid.Row>
    </Grid>
  </Container>
})

export default App;
