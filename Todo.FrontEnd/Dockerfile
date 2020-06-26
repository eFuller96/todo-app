# Base image. : Node.js is a JavaScript-based platform for server-side and networking applications.
FROM node:lts-alpine3.11 AS frontend-build

# Defining the work directory in the image for the rest of the instructions below to run in
WORKDIR /app 

# Copy everything in *this* directory ('this' being where Dockerfile lives) into the /src directory of my image.
COPY ./package.json ./
COPY ./yarn.lock ./

# Get the dependencies for my app
RUN yarn
COPY . ./
RUN yarn build

FROM nginx:alpine

COPY --from=frontend-build ./app/build /website

# This is just for documentation purposes. my react app is running on 3000 by default.
# to run a container, have to map port to 3000. (e.g. -p 80:3000)
EXPOSE 3000

COPY ./default.conf /etc/nginx/conf.d/default.conf

# Run yarn start when I run my container
ENTRYPOINT [ "nginx", "-g", "daemon off;" ]
