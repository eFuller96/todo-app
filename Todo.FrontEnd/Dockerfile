# Base image. : Node.js is a JavaScript-based platform for server-side and networking applications.
FROM node:latest AS frontend-build
# Defining the work directory in the image for the rest of the instructions below to run in
WORKDIR /app 
# Copy everyhting in *this* directory ('this' being where Dockerfile lives) into the /src directory of my image.
COPY . ./
# Build the app in the image
RUN yarn
RUN yarn build
# This is just for documentation purposes. my react app is running on 3000 by default.
# to run a container, have to map port to 3000. (e.g. -p 80:3000)
EXPOSE 3000

# Run yarn start when I run my container
ENTRYPOINT [ "yarn", "start" ]
