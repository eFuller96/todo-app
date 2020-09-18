import config from "../config.js";

const get = (uri) => {
  return fetch(uri, {
    method: "GET",
    headers: {
      "Access-Control-Allow-Origin": "*",
    },
  });
};

const post = (uri, payload) => {
  return fetch(uri, {
    method: "POST",
    headers: {
      "Access-Control-Allow-Origin": "*",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(payload),
  });
};

const put = (uri, payload) => {
  return fetch(uri, {
    method: "PUT",
    headers: {
      "Access-Control-Allow-Origin": "*",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(payload),
  });
};

const baseUrl = "https://localhost:5001";

export function getItems() {
  return get(`${baseUrl}/item`);
}

export function saveItem(payload) {
  return post(`${baseUrl}/item`, payload);
}

export function updateItem(payload) {
  return put(`${baseUrl}/item`, payload);
}
