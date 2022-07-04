# cardano-unity
Cardano games assets for Unity

## Blockfrost.io Client for Unity

This repository contains lighthweight Unity-specific client for interacting with blockfrost.io API. It's built on [UniTask](https://github.com/Cysharp/UniTask) for allocation-free async operations and uses Unity's native HTTP client (`UnityWebRequest`) and JSON parser (`JsonUtility`).

### Installation

#### Unity Asset Store

Not yet published

#### Package Manager

Client can be installed using Unity Package Manager using git. Go to Package Manager, select *Add package from git URL...* and enter
`https://github.com/fivebinaries/cardano-unity.git?path=src/Blockfrost.io`.
NOTE: Dependancy has to be installed manually, see [Installing UniTask](https://github.com/Cysharp/UniTask#install-via-git-url)

#### Manual

You can copy [Blockfrost.io](src/Blockfrost.io) folder into your project. Installing dependancy is required.

### Usage

#### Getting started

1. Get your own `project_id` from [blockfrost.dev](https://blockfrost.dev/docs/overview/getting-started#creating-first-project)
2. Create configuration `Create > Blockfrost.io API > Configuration` and fill in the `project_id`
3. In your MonoBehaviour create new instance of `Blockfrost.API` by passing in reference to your configuration
4. You can now call the API

### Example

```
var config = new Blockfrost.Configuration{
	ProjectID = myProjectID;
};
var client = Blockfrost.API(config);
var latestBlock = await client.GetLatestBlock();
Debug.Log(response.hash);
```

### Listing

Some endpoints allow certain listing operations (number of items in a list, order, ...). There are three filters available
`Blockfrost.Listing`, `Blockfrost.OrderedListing`, and `Blockfrost.TargetableOrderedListing` that can be passed to specific methods.

```
api.GetBlockTransactions(hash, new Listing{count = 10})
```

### Errors

Errors from `UnityWebRequest` are returned as is.

### Development

[src/Blockfrost.io](src/Blockfrost.io)

## Demo

Demo using Nami wallet can be found [here](src/Examples).

## Generator

Scripts for preparing new endpoints are located in [src/Generator](src/Generator).

## TODO

- [ ] Support for complex responses (any of)
- [ ] Support for POST methods
- [ ] Streamlined errors
- [ ] Textures
