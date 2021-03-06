import React, { useState, useEffect } from "react";
import {
  Header,
  Container,
  Form,
  Button,
  Divider,
  Grid,
  Input,
  List,
  Checkbox,
} from "semantic-ui-react";
import { getItems as getItemsAPI } from "./api/items";
import { saveItem as saveItemAPI } from "./api/items";
import { updateItem as updateItemAPI } from "./api/items";
import { deleteItem as deleteItemAPI } from "./api/items";
import "./App.css";
import moment from "moment";

const App = () => {
  const [itemToAdd, setItemToAdd] = useState("");
  const [itemList, setItemList] = useState([]);

  useEffect(() => {
    getItems();
  }, []);

  const getItems = async () => {
    const response = await getItemsAPI();
    if (!response.ok) {
      throw new Error("HTTP status " + response.status);
    }
    const data = await response.json();
    if (data) {
      const sortedList = Object.values(data).sort((item) => (item.taskDone ? 1 : 0))
      setItemList(sortedList);
    }
  };

  const postItem = async (newItem) => {
    const response = await saveItemAPI(newItem);
    if (!response.ok) {
      throw new Error("HTTP status " + response.status);
    }
    const data = await response.json();
    if (data) {
      const sortedList = Object.values(data).sort((item) => (item.taskDone ? 1 : 0));
      setItemList(Object.values(sortedList));
    }
    setItemToAdd("");
  };

  const updateItem = async (itemToUpdate) => {
    const response = await updateItemAPI(itemToUpdate);
    if (!response.ok) {
      throw new Error("HTTP status " + response.status);
    }
    const data = await response.json();
    if (data) {
      const sortedList = Object.values(data).sort((item) => (item.taskDone ? 1 : 0))
      setItemList(sortedList);
    }
  };

  const deleteItem = async (itemToRemove) => {
    const response = await deleteItemAPI(itemToRemove.id);
    if (!response.ok) {
      throw new Error("HTTP status " + response.status);
    }
    const data = await response.json();
    if (data) {
      const sortedList = Object.values(data).sort((item) => (item.taskDone ? 1 : 0))
      setItemList(sortedList);
    }
  };

  const handleOnSubmit = async () => {
    const newItem = {
      name: itemToAdd,
      done: false,
      completedTime: null,
    };

    postItem(newItem);
  };

  const handleOnChange = (e) => {
    setItemToAdd(e.target.value);
  };

  const handleCheck = (item) => {
    const timeStamp = moment(Date.now())
    item.taskDone = true;
    item.completedTime = timeStamp;

    updateItem(item);
  };

  const formatTime = (time) => {
    const formattedTime =
      moment(Date.now()).format("l") + " " + moment(time).format("LT");
    return formattedTime
  }

  const removeItem = (item) => {
    deleteItem(item);
  };

  return (
    <Container className="page">
      <Header className="app-header">Todo App</Header>
      <Divider />
      <Grid columns={2}>
        <Grid.Row className="display-flex">
          <Grid.Column>
            <Grid.Row className="add-item">
              <Form>
                <Form.Field>
                  <Input
                    placeholder="To do"
                    value={itemToAdd}
                    onChange={handleOnChange}
                  />
                </Form.Field>
                <Button
                  disabled={itemToAdd === ""}
                  type="submit"
                  onClick={handleOnSubmit}
                >
                  Add
                </Button>
              </Form>
            </Grid.Row>
          </Grid.Column>
          <Grid.Column className="items-box">
            <label>To Do:</label>
            <List className="items-scroll ">
              {itemList.map((item, key) => {
                return (
                  <List.Item key={key} >
                    <List.Content
                      className={`list-item ${item.taskDone ? "item-completed" : ""
                        }`}
                    >
                      <Checkbox
                        checked={item.taskDone}
                        disabled={item.taskDone}
                        onClick={() => handleCheck(item)}
                        label={item.name}
                      />
                      <div className="time-stamp">{item.completedTime ? formatTime(item.completedTime) : ""}</div>
                      <div
                        onClick={() => removeItem(item)}
                        className="remove-icon"
                      >
                        x
                      </div>
                    </List.Content>
                  </List.Item>
                );
              })}
            </List>
          </Grid.Column>
        </Grid.Row>
      </Grid>
    </Container>
  );
};

export default App;
