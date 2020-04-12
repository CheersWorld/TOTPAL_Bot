# TOTPAL (Two of these people are lying)-Bot
# SETUP
```
▄▄▄█████▓ ▒█████  ▄▄▄█████▓ ██▓███   ▄▄▄       ██▓    
▓  ██▒ ▓▒▒██▒  ██▒▓  ██▒ ▓▒▓██░  ██▒▒████▄    ▓██▒    
▒ ▓██░ ▒░▒██░  ██▒▒ ▓██░ ▒░▓██░ ██▓▒▒██  ▀█▄  ▒██░    
░ ▓██▓ ░ ▒██   ██░░ ▓██▓ ░ ▒██▄█▓▒ ▒░██▄▄▄▄██ ▒██░    
  ▒██▒ ░ ░ ████▓▒░  ▒██▒ ░ ▒██▒ ░  ░ ▓█   ▓██▒░██████▒
  ▒ ░░   ░ ▒░▒░▒░   ▒ ░░   ▒▓▒░ ░  ░ ▒▒   ▓▒█░░ ▒░▓  ░
    ░      ░ ▒ ▒░     ░    ░▒ ░       ▒   ▒▒ ░░ ░ ▒  ░
  ░      ░ ░ ░ ▒    ░      ░░         ░   ▒     ░ ░   
             ░ ░                          ░  ░    ░  ░
                                                      
```

This bot was intentionally uploaded without a bot-token. 
You will need to supply this for the bot to work, otherwise the application wont start. 

1) Get your Bot-Token:
Head off to discord and create a new bot-account. You can do this at https://discordapp.com/developers/applications. Create a new application. 
This won't go into too much detail. What we need is the Token, which can be found under "Bot". Just click "Copy Token". 

2) Add the Token to "Program.cs"
In line 44 you will find Token = "". Paste your Token between the quotes. You will need to clone the solution for this. 

3) You're done.
Add the bot to your server, test it with !god or !logo, it should work now. 


# USAGE

You can register your article by writing !SetMyArticle to the bot, in a private chat. It will store it. 
If you want to change your mind or want to update it, simply write it again. The bot overwrites your old entry. 

Use !GetRandomArticle to get a random article returned. Do this in a public server ideally, so that everyone can see it. 

If you ever need to know you Article in between rounds, use !GetMyArticle. If you want to leave the game, type !leave.



# LANGUAGE

This bot was written in German. You can change the Reply-Text in "CommandsManager.cs" to any language you like. 
I have tried to include a little description about what is said in each command. 



# RIGHTS AND STUFF

I wrote this bot in April of 2020. If you use this code I'd be happy if you let me know, same for any update requests you have. 
Apart from that, well, enjoy it. 
