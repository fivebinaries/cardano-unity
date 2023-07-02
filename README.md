<img src=".github/assets/unity_cardano_network.png" align="right" height="250" />


<a href="https://fivebinaries.com/"><img src="https://img.shields.io/badge/made%20by-Five%20Binaries-darkviolet.svg?style=flat-square" /></a>

# Cardano games assets for Unity 

This repository contains the code and configuration files of Cardano game assets for Unity.

It is a lighthweight Unity-specific client for interacting with blockfrost.io API. It's built on [UniTask](https://github.com/Cysharp/UniTask) for allocation-free async operations and uses Unity's native HTTP client (`UnityWebRequest`) and JSON parser (`JsonUtility`).

<p align="center">
  <a href="#installation">Installation</a> •
  <a href="#cardano-api">Cardano</a> •
  <a href="#milkomeda-api">Milkomeda</a> •
  <a href="#demo">Demo</a> 
</p>
<br><br>

## Installation

### Unity Asset Store

We're going to publish this package to the Asset Story in the near future.

### Package Manager

Client can be installed using Unity Package Manager using git.

* Go to Package Manager, select *Add package from git URL...* 
* Enter `https://github.com/fivebinaries/cardano-unity.git?path=src/Blockfrost.io`

NOTE: Dependancy has to be installed manually if they are missing, see [Installing UniTask](https://github.com/Cysharp/UniTask#install-via-git-url).

### Manual installation

You can copy [Blockfrost.io](src/Blockfrost.io) folder into your project. Installing dependancy is required.

## Cardano API

### Getting started

1. Get your own `PROJECT_ID` from [blockfrost.io](https://blockfrost.dev/docs/overview/getting-started#creating-first-project)
2. Create configuration _Create_ → _Blockfrost.io API_ → _Configuration_ and fill in the `PROJECT_ID`
3. In your MonoBehaviour create new instance of _Blockfrost.Cardano_ by passing in reference to your configuration
4. You can now call the API and access the Cardano blockchain

### Example

```csharp
var config = new Blockfrost.Configuration{
  ProjectID = myProjectID;
};

var client = Blockfrost.Cardano(config);
var latestBlock = await client.GetLatestBlock();

Debug.Log(response.hash);
```

### Listing

Some endpoints allow certain listing operations (number of items in a list, order, .etc). There are three filters available
`Blockfrost.Listing`, `Blockfrost.OrderedListing`, and `Blockfrost.TargetableOrderedListing` that can be passed to specific methods.

```csharp
api.GetBlockTransactions(hash, new Listing{count = 10})
```

### Errors

Handle original errors from `UnityWebRequest`.

## Milkomeda API

To use [Milkomeda API](https://blockfrost.dev/docs/start-building/milkomeda#supported-json-rpc-api-calls) follow steps in Cardano section, but select Milkomeda in your Blockfrost API configuration. The client currently only supports raw json messages on both input and output.

```csharp
var client = Blockfrost.Milkomeda();

var data = @"{""jsonrpc"": ""2.0"", ""method"": ""net_version"", ""params"": [], ""id"": 1}";
var response = await client.RPC(data);

Debug.Log(response);
```

## Demo

Demo using [Nami wallet](https://namiwallet.io/) can be found [here](https://fivebinaries.github.io/cardano-unity/src/Examples/Demo/) and its sources [here](src/Examples). In this simple game, the door won't open until your wallet contains a specific NFT.
