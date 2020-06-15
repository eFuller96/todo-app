import React, { useState, useEffect } from 'react';
import {
  Header, Container, Form,
  Button, Divider, Grid,
  Input, List, Checkbox
} from 'semantic-ui-react'
import { getItems as getItemsAPI } from './api/items'
import './App.css';
import moment from 'moment';

const App = (() => {
  const [itemToAdd, setItemToAdd] = useState('')
  const [itemList, setItemList] = useState([])

  const getItems = async () => {
    const response = await getItemsAPI()
    if (response.status === 200) {
      console.error("response: ", response)
    }
  }

  useEffect(() => {
    console.error("making api call")
    getItems()
  })

  const handleOnSubmit = () => {
    const newItem = {
      name: itemToAdd,
      done: false,
      completedTime: null
    }
    const newItemList = [...itemList, newItem]
    newItemList.sort((x) => {
      if (x.done) {
        return 1
      }
    })
    setItemList(newItemList)
    setItemToAdd('')
  }

  const handleOnChange = (e) => {
    setItemToAdd(e.target.value)
  }

  const handleCheck = (indexToCheck) => {
    const timeStamp = moment(Date.now()).format('l') + ' ' + moment(Date.now()).format('LT')
    const updatedItemList = [...itemList]
    updatedItemList[indexToCheck].done = true
    updatedItemList[indexToCheck].completedTime = timeStamp
    updatedItemList.sort((x) => {
      if (x.done) {
        return 1
      }
    });

    setItemList(updatedItemList)
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
                <List.Content className={`list-item ${item.done ? "item-completed" : ""}`}>
                  <Checkbox checked={item.done} disabled={item.done} onClick={() => handleCheck(index)} label={item.name} />
                  <div className='time-stamp'>{item.completedTime}</div>
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
