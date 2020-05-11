<template>
<v-app>
  <v-content>
    <v-container>
      <v-card class="mx-auto" style="max-width:500px">
        <v-system-bar color="indigo darken-1"></v-system-bar>
        <v-spacer></v-spacer>
        <v-toolbar color="indigo lighten-1">
          <v-btn icon v-on:click="toTopPage">
            <v-icon>mdi-arrow-left</v-icon>
          </v-btn>
          <v-card-title>君のエモを共有しよう</v-card-title>
          <v-spacer></v-spacer>
        </v-toolbar>
        <div class="pa-4 pt-6">
          <v-text-field
            color="indigo lighten-5"
            label="エモ"
            v-model="Emotion"
            @keydown.enter="trigger"
          ></v-text-field>
          <v-divider></v-divider>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn v-on:click="sendEmotion" v-bind:disabled="IsDisconnected" >エモ～い</v-btn>
          </v-card-actions>
        </div>
      </v-card>
    </v-container>
  </v-content>
</v-app>
</template>

<script>
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr'

export default {
    data() {
        return {
            Emotion: "えももも",
            IsDisconnected : true,
            connection : null
        }
    },
    methods: {
        sendEmotion() {
            console.log("send emotion")
            let num = this.$route.query.groupNumber
            console.log("num = " + num)
            this.connection.invoke("SendEmotion",num,this.Emotion)
            .catch(err => console.error(err));
            this.Emotion = ""
        },
        trigger(event) {
          if(event.keyCode !== 13) return
          this.sendEmotion()
          return
        },
        toTopPage() {
            this.$router.push({ path: '/'})
        }
    },
    created() {
      this.connection = new HubConnectionBuilder()
                        .withUrl('https://www.share-emotion-site.com:443/hub/emotion')
                        .configureLogging(LogLevel.Information)
                        .build()

      this.connection.start()
      .then( () => { console.log("connected test"); this.IsDisconnected=false})
    }
}
</script>

<style>
</style>