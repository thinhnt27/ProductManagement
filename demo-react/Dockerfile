# Build stage
FROM node:18 AS build

WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application files
COPY . .

# Build the Vite app
RUN npm run build

# Production stage
FROM nginx:alpine

# Set environment variables
ENV VITE_API_URL=http://128.199.177.223:8888

# Copy the build output to the Nginx server
COPY --from=build /app/dist /usr/share/nginx/html

# Nginx configuration to handle SPA routes
COPY nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
