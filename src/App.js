import React, { useState } from 'react';
import {
  Header, Container, Form,
  Button, Divider, Grid,
  Input, List, Checkbox
} from 'semantic-ui-react'
import './App.css';

const App = (() => {
  const [itemToAdd, setItemToAdd] = useState('')
  const [itemList, setItemList] = useState([])

  const handleOnSubmit = () => {
    const newItem = {
      name: itemToAdd,
      done: false,
      completedTime: null
    }
    const newItemList = [...itemList, newItem]
    setItemList(newItemList)
    setItemToAdd('')
  }

  const handleOnChange = (e) => {
    setItemToAdd(e.target.value)
  }

  const handleCheck = (indexToCheck) => {
    const timeStamp = Date.now();
    const updatedItemList = [...itemList]
    const item = {
      name: updatedItemList[indexToCheck],
      completedTime: timeStamp
    }
  }

  const removeItem = (indexToRemove) => {
    setItemList(itemList.filter((_, index) => (index !== indexToRemove)))
  }

  return <Container className='page'>
    <Header className='app-header'>Todo App</Header>
    <Divider />
    <Grid columns={3}>
      <Grid.Row>
        <Grid.Column width={1}>
          <Grid.Row className='add-item'>
            <Form>
              <Form.Field>
                <Input placeholder='To do' value={itemToAdd} onChange={handleOnChange} />
              </Form.Field>
              <Button disabled={itemToAdd === ''} type='submit' onClick={handleOnSubmit}>Add</Button>
            </Form>
          </Grid.Row>
        </Grid.Column>
        <Grid.Column width={2} className='items-box'>
          <label>To Do:</label>
          <List className='items-scroll '>
            {itemList.map((item, index) => {
              return <List.Item key={index}>
                <List.Content className='list-item'>
                  <Checkbox onClick={() => handleCheck(index)} label={item.name} />
                  <div onClick={() => removeItem(index)} className='remove-icon'>x</div>
                </List.Content>
              </List.Item>
            })}
          </List>
        </Grid.Column>
      </Grid.Row>
    </Grid>
  </Container>
})

export default App;
