# ARK RCON CLI

## Introduction

Ark RCON Cli , it's a net/core win/linux console tool to send commands to ark server in a console

It is intended to be used in your own batch scripts.

Based on CoreRCON Library (https://github.com/Challengermode/CoreRcon).


## Usage
use rcon.exe in command line in your windows / linux console 
you can send a specific rcom command, or a secuence of rcom commands

To send a specific command

**rcon.exe ip=127.0.0.1 port=8800 pwd=mypassword cmd="listplayers"**

**parameters**

ip= ip of your ark server
port= tcp port of your server
pwd= specifies the serverpassword
cmd= rcon command that you want to send

To send a sequence commands

**rcon.exe ip=127.0.0.1 port=8800 pwd=mypassword file=filecommands.txt**

**parameters**

ip= ip of your ark server
port= tcp port of your server
pwd= specifies the serverpassword
file= text file that contains the secuence commands.
