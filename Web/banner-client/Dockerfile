FROM node:16-alpine as build

# Create app directory
WORKDIR /app

# Install app dependencies
# A wildcard is used to ensure both package.json AND package-lock.json are copied
# where available (npm@5+)
COPY package*.json ./
RUN npm install -g @quasar/cli
RUN yarn

# Bundle app source
COPY . .
RUN quasar build

FROM nginx
COPY --from=build /app/dist/spa /usr/share/nginx/html
