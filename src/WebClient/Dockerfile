FROM node:14.2.0 AS build
WORKDIR /src
COPY . .
RUN npm install
RUN npm run build

FROM node:14.2.0-alpine AS final

WORKDIR /app
COPY --from=build /src .
ENTRYPOINT ["npm", "start"]
EXPOSE 80
