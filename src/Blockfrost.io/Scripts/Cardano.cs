using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Blockfrost {
    public class Cardano : Client {
        public Cardano() : base() { }
        public Cardano(Configuration config) : base(config) { }
        /// <summary>
        /// Root endpoint has no other function than to point end users to documentation.
        /// </summary>
        /// <remarks>GET /</remarks>
        public async UniTask<RootEndpoint> GetRootEndpoint() {
            const string path = "/";
            var pathParams = new Dictionary<string, object>();
            return await Get<RootEndpoint>(path, pathParams);
        }

        /// <summary>
        /// Return backend status as a boolean. Your application should handle situations when backend for the given chain is unavailable.
        /// </summary>
        /// <remarks>GET /health</remarks>
        public async UniTask<BackendHealthStatus> GetBackendHealthStatus() {
            const string path = "/health";
            var pathParams = new Dictionary<string, object>();
            return await Get<BackendHealthStatus>(path, pathParams);
        }

        /// <summary>
        /// This endpoint provides the current UNIX time. Your application might
        /// use this to verify if the client clock is not out of sync.
        /// </summary>
        /// <remarks>GET /health/clock</remarks>
        public async UniTask<CurrentBackendTime> GetCurrentBackendTime() {
            const string path = "/health/clock";
            var pathParams = new Dictionary<string, object>();
            return await Get<CurrentBackendTime>(path, pathParams);
        }

        /// <summary>
        /// Return the latest block available to the backends, also known as the
        /// tip of the blockchain.
        /// </summary>
        /// <remarks>GET /blocks/latest</remarks>
        public async UniTask<BlockContent> GetLatestBlock() {
            const string path = "/blocks/latest";
            var pathParams = new Dictionary<string, object>();
            return await Get<BlockContent>(path, pathParams);
        }

        /// <summary>
        /// Return the transactions within the latest block.
        /// </summary>
        /// <remarks>GET /blocks/latest/txs</remarks>
        public async UniTask<string[]> GetLatestBlockTransactions(OrderedListing query = null) {
            const string path = "/blocks/latest/txs";
            var pathParams = new Dictionary<string, object>();
            return await GetArray<string>(path, pathParams, query);
        }

        /// <summary>
        /// Return the content of a requested block.
        /// </summary>
        /// <remarks>GET /blocks/{hash_or_number}</remarks>
        /// <param name="hashOrNumber">Hash or number of the requested block.</param>
        public async UniTask<BlockContent> GetSpecificBlock(string hashOrNumber) {
            const string path = "/blocks/{hash_or_number}";
            var pathParams = new Dictionary<string, object>(){
                {"hash_or_number", hashOrNumber},
            };
            return await Get<BlockContent>(path, pathParams);
        }

        /// <summary>
        /// Return the list of blocks following a specific block.
        /// </summary>
        /// <remarks>GET /blocks/{hash_or_number}/next</remarks>
        /// <param name="hashOrNumber">Hash of the requested block.</param>
        public async UniTask<BlockContent[]> GetListingOfNextBlocks(string hashOrNumber, Listing query = null) {
            const string path = "/blocks/{hash_or_number}/next";
            var pathParams = new Dictionary<string, object>(){
                {"hash_or_number", hashOrNumber},
            };
            return await GetArray<BlockContent>(path, pathParams, query);
        }

        /// <summary>
        /// Return the list of blocks preceding a specific block.
        /// </summary>
        /// <remarks>GET /blocks/{hash_or_number}/previous</remarks>
        /// <param name="hashOrNumber">Hash of the requested block</param>
        public async UniTask<BlockContent[]> GetListingOfPreviousBlocks(string hashOrNumber, Listing query = null) {
            const string path = "/blocks/{hash_or_number}/previous";
            var pathParams = new Dictionary<string, object>(){
                {"hash_or_number", hashOrNumber},
            };
            return await GetArray<BlockContent>(path, pathParams, query);
        }

        /// <summary>
        /// Return the content of a requested block for a specific slot.
        /// </summary>
        /// <remarks>GET /blocks/slot/{slot_number}</remarks>
        /// <param name="slotNumber">Slot position for requested block.</param>
        public async UniTask<BlockContent> GetSpecificBlockInASlot(int slotNumber) {
            const string path = "/blocks/slot/{slot_number}";
            var pathParams = new Dictionary<string, object>(){
                {"slot_number", slotNumber},
            };
            return await Get<BlockContent>(path, pathParams);
        }

        /// <summary>
        /// Return the content of a requested block for a specific slot in an epoch.
        /// </summary>
        /// <remarks>GET /blocks/epoch/{epoch_number}/slot/{slot_number}</remarks>
        /// <param name="epochNumber">Epoch for specific epoch slot.</param>
        /// <param name="slotNumber">Slot position for requested block.</param>
        public async UniTask<BlockContent> GetSpecificBlockInASlotInAnEpoch(int epochNumber, int slotNumber) {
            const string path = "/blocks/epoch/{epoch_number}/slot/{slot_number}";
            var pathParams = new Dictionary<string, object>(){
                {"epoch_number", epochNumber},
                {"slot_number", slotNumber},
            };
            return await Get<BlockContent>(path, pathParams);
        }

        /// <summary>
        /// Return the transactions within the block.
        /// </summary>
        /// <remarks>GET /blocks/{hash_or_number}/txs</remarks>
        /// <param name="hashOrNumber">Hash of the requested block.</param>
        public async UniTask<string[]> GetBlockTransactions(string hashOrNumber, OrderedListing query = null) {
            const string path = "/blocks/{hash_or_number}/txs";
            var pathParams = new Dictionary<string, object>(){
                {"hash_or_number", hashOrNumber},
            };
            return await GetArray<string>(path, pathParams, query);
        }

        /// <summary>
        /// Return list of addresses affected in the specified block with additional information, sorted by the bech32 address, ascending.
        /// </summary>
        /// <remarks>GET /blocks/{hash_or_number}/addresses</remarks>
        /// <param name="hashOrNumber">Hash of the requested block.</param>
        public async UniTask<BlockContentAddresses[]> GetAddressesAffectedInASpecificBlock(string hashOrNumber, Listing query = null) {
            const string path = "/blocks/{hash_or_number}/addresses";
            var pathParams = new Dictionary<string, object>(){
                {"hash_or_number", hashOrNumber},
            };
            return await GetArray<BlockContentAddresses>(path, pathParams, query);
        }

        /// <summary>
        /// Return the information about blockchain genesis.
        /// </summary>
        /// <remarks>GET /genesis</remarks>
        public async UniTask<GenesisContent> GetBlockchainGenesis() {
            const string path = "/genesis";
            var pathParams = new Dictionary<string, object>();
            return await Get<GenesisContent>(path, pathParams);
        }

        /// <summary>
        /// Return the information about the latest, therefore current, epoch.
        /// </summary>
        /// <remarks>GET /epochs/latest</remarks>
        public async UniTask<EpochContent> GetLatestEpoch() {
            const string path = "/epochs/latest";
            var pathParams = new Dictionary<string, object>();
            return await Get<EpochContent>(path, pathParams);
        }

        /// <summary>
        /// Return the protocol parameters for the latest epoch.
        /// </summary>
        /// <remarks>GET /epochs/latest/parameters</remarks>
        public async UniTask<EpochParamContent> GetLatestEpochProtocolParameters() {
            const string path = "/epochs/latest/parameters";
            var pathParams = new Dictionary<string, object>();
            return await Get<EpochParamContent>(path, pathParams);
        }

        /// <summary>
        /// Return the content of the requested epoch.
        /// </summary>
        /// <remarks>GET /epochs/{number}</remarks>
        /// <param name="number">Number of the epoch</param>
        public async UniTask<EpochContent> GetSpecificEpoch(int number) {
            const string path = "/epochs/{number}";
            var pathParams = new Dictionary<string, object>(){
                {"number", number},
            };
            return await Get<EpochContent>(path, pathParams);
        }

        /// <summary>
        /// Return the list of epochs following a specific epoch.
        /// </summary>
        /// <remarks>GET /epochs/{number}/next</remarks>
        /// <param name="number">Number of the requested epoch.</param>
        public async UniTask<EpochContent[]> GetListingOfNextEpochs(int number, Listing query = null) {
            const string path = "/epochs/{number}/next";
            var pathParams = new Dictionary<string, object>(){
                {"number", number},
            };
            return await GetArray<EpochContent>(path, pathParams, query);
        }

        /// <summary>
        /// Return the list of epochs preceding a specific epoch.
        /// </summary>
        /// <remarks>GET /epochs/{number}/previous</remarks>
        /// <param name="number">Number of the epoch</param>
        public async UniTask<EpochContent[]> GetListingOfPreviousEpochs(int number, Listing query = null) {
            const string path = "/epochs/{number}/previous";
            var pathParams = new Dictionary<string, object>(){
                {"number", number},
            };
            return await GetArray<EpochContent>(path, pathParams, query);
        }

        /// <summary>
        /// Return the blocks minted for the epoch specified.
        /// </summary>
        /// <remarks>GET /epochs/{number}/blocks</remarks>
        /// <param name="number">Number of the epoch</param>
        public async UniTask<string[]> GetBlockDistribution(int number, OrderedListing query = null) {
            const string path = "/epochs/{number}/blocks";
            var pathParams = new Dictionary<string, object>(){
                {"number", number},
            };
            return await GetArray<string>(path, pathParams, query);
        }

        /// <summary>
        /// Return the block minted for the epoch specified by stake pool.
        /// </summary>
        /// <remarks>GET /epochs/{number}/blocks/{pool_id}</remarks>
        /// <param name="number">Number of the epoch</param>
        /// <param name="poolId">Stake pool ID to filter</param>
        public async UniTask<string[]> GetBlockDistributionByPool(int number, string poolId, OrderedListing query = null) {
            const string path = "/epochs/{number}/blocks/{pool_id}";
            var pathParams = new Dictionary<string, object>(){
                {"number", number},
                {"pool_id", poolId},
            };
            return await GetArray<string>(path, pathParams, query);
        }

        /// <summary>
        /// Return the protocol parameters for the epoch specified.
        /// </summary>
        /// <remarks>GET /epochs/{number}/parameters</remarks>
        /// <param name="number">Number of the epoch</param>
        public async UniTask<EpochParamContent> GetProtocolParameters(int number) {
            const string path = "/epochs/{number}/parameters";
            var pathParams = new Dictionary<string, object>(){
                {"number", number},
            };
            return await Get<EpochParamContent>(path, pathParams);
        }

        /// <summary>
        /// Return content of the requested transaction.
        /// </summary>
        /// <remarks>GET /txs/{hash}</remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        public async UniTask<TxContent> GetSpecificTransaction(string hash) {
            const string path = "/txs/{hash}";
            var pathParams = new Dictionary<string, object>(){
                {"hash", hash},
            };
            return await Get<TxContent>(path, pathParams);
        }

        /// <summary>
        /// Return the inputs and UTXOs of the specific transaction.
        /// </summary>
        /// <remarks>GET /txs/{hash}/utxos</remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        public async UniTask<TxContentUtxo> GetTransactionUTXOs(string hash) {
            const string path = "/txs/{hash}/utxos";
            var pathParams = new Dictionary<string, object>(){
                {"hash", hash},
            };
            return await Get<TxContentUtxo>(path, pathParams);
        }

        /// <summary>
        /// Obtain information about (de)registration of stake addresses within a transaction.
        /// </summary>
        /// <remarks>GET /txs/{hash}/stakes</remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        public async UniTask<TxContentStakeAddr[]> GetTransactionStakeAddressesCertificates(string hash) {
            const string path = "/txs/{hash}/stakes";
            var pathParams = new Dictionary<string, object>(){
                {"hash", hash},
            };
            return await GetArray<TxContentStakeAddr>(path, pathParams);
        }

        /// <summary>
        /// Obtain information about delegation certificates of a specific transaction.
        /// </summary>
        /// <remarks>GET /txs/{hash}/delegations</remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        public async UniTask<TxContentDelegations[]> GetTransactionDelegationCertificates(string hash) {
            const string path = "/txs/{hash}/delegations";
            var pathParams = new Dictionary<string, object>(){
                {"hash", hash},
            };
            return await GetArray<TxContentDelegations>(path, pathParams);
        }

        /// <summary>
        /// Obtain information about withdrawals of a specific transaction.
        /// </summary>
        /// <remarks>GET /txs/{hash}/withdrawals</remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        public async UniTask<TxContentWithdrawals[]> GetTransactionWithdrawal(string hash) {
            const string path = "/txs/{hash}/withdrawals";
            var pathParams = new Dictionary<string, object>(){
                {"hash", hash},
            };
            return await GetArray<TxContentWithdrawals>(path, pathParams);
        }

        /// <summary>
        /// Obtain information about Move Instantaneous Rewards (MIRs) of a specific transaction.
        /// </summary>
        /// <remarks>GET /txs/{hash}/mirs</remarks>
        /// <param name="hash">Hash of the requested transaction.</param>
        public async UniTask<TxContentMirs[]> GetTransactionMIRs(string hash) {
            const string path = "/txs/{hash}/mirs";
            var pathParams = new Dictionary<string, object>(){
                {"hash", hash},
            };
            return await GetArray<TxContentMirs>(path, pathParams);
        }

        /// <summary>
        /// Obtain information about stake pool registration and update certificates of a specific transaction.
        /// </summary>
        /// <remarks>GET /txs/{hash}/pool_updates</remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        public async UniTask<TxContentPoolCerts[]> GetTransactionStakePoolRegistrationAndUpdateCertificates(string hash) {
            const string path = "/txs/{hash}/pool_updates";
            var pathParams = new Dictionary<string, object>(){
                {"hash", hash},
            };
            return await GetArray<TxContentPoolCerts>(path, pathParams);
        }

        /// <summary>
        /// Obtain information about stake pool retirements within a specific transaction.
        /// </summary>
        /// <remarks>GET /txs/{hash}/pool_retires</remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        public async UniTask<TxContentPoolRetires[]> GetTransactionStakePoolRetirementCertificates(string hash) {
            const string path = "/txs/{hash}/pool_retires";
            var pathParams = new Dictionary<string, object>(){
                {"hash", hash},
            };
            return await GetArray<TxContentPoolRetires>(path, pathParams);
        }

        /// <summary>
        /// Obtain the transaction metadata.
        /// </summary>
        /// <remarks>GET /txs/{hash}/metadata</remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        public async UniTask<TxContentMetadata[]> GetTransactionMetadata(string hash) {
            const string path = "/txs/{hash}/metadata";
            var pathParams = new Dictionary<string, object>(){
                {"hash", hash},
            };
            return await GetArray<TxContentMetadata>(path, pathParams);
        }

        /// <summary>
        /// Obtain the transaction metadata in CBOR.
        /// </summary>
        /// <remarks>GET /txs/{hash}/metadata/cbor</remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        public async UniTask<TxContentMetadataCbor[]> GetTransactionMetadataInCBOR(string hash) {
            const string path = "/txs/{hash}/metadata/cbor";
            var pathParams = new Dictionary<string, object>(){
                {"hash", hash},
            };
            return await GetArray<TxContentMetadataCbor>(path, pathParams);
        }

        /// <summary>
        /// Obtain the transaction redeemers.
        /// </summary>
        /// <remarks>GET /txs/{hash}/redeemers</remarks>
        /// <param name="hash">Hash of the requested transaction</param>
        public async UniTask<TxContentRedeemers[]> GetTransactionRedeemers(string hash) {
            const string path = "/txs/{hash}/redeemers";
            var pathParams = new Dictionary<string, object>(){
                {"hash", hash},
            };
            return await GetArray<TxContentRedeemers>(path, pathParams);
        }

        /// <summary>
        /// Obtain information about a specific stake account.
        /// </summary>
        /// <remarks>GET /accounts/{stake_address}</remarks>
        /// <param name="stakeAddress">Bech32 stake address.</param>
        public async UniTask<AccountContent> GetSpecificAccountAddress(string stakeAddress) {
            const string path = "/accounts/{stake_address}";
            var pathParams = new Dictionary<string, object>(){
                {"stake_address", stakeAddress},
            };
            return await Get<AccountContent>(path, pathParams);
        }

        /// <summary>
        /// Obtain information about the reward history of a specific account.
        /// </summary>
        /// <remarks>GET /accounts/{stake_address}/rewards</remarks>
        /// <param name="stakeAddress">Bech32 stake address.</param>
        public async UniTask<AccountRewardContent[]> GetAccountRewardHistory(string stakeAddress, OrderedListing query = null) {
            const string path = "/accounts/{stake_address}/rewards";
            var pathParams = new Dictionary<string, object>(){
                {"stake_address", stakeAddress},
            };
            return await GetArray<AccountRewardContent>(path, pathParams, query);
        }

        /// <summary>
        /// Obtain information about the history of a specific account.
        /// </summary>
        /// <remarks>GET /accounts/{stake_address}/history</remarks>
        /// <param name="stakeAddress">Bech32 stake address.</param>
        public async UniTask<AccountHistoryContent[]> GetAccountHistory(string stakeAddress, OrderedListing query = null) {
            const string path = "/accounts/{stake_address}/history";
            var pathParams = new Dictionary<string, object>(){
                {"stake_address", stakeAddress},
            };
            return await GetArray<AccountHistoryContent>(path, pathParams, query);
        }

        /// <summary>
        /// Obtain information about the delegation of a specific account.
        /// </summary>
        /// <remarks>GET /accounts/{stake_address}/delegations</remarks>
        /// <param name="stakeAddress">Bech32 stake address.</param>
        public async UniTask<AccountDelegationContent[]> GetAccountDelegationHistory(string stakeAddress, OrderedListing query = null) {
            const string path = "/accounts/{stake_address}/delegations";
            var pathParams = new Dictionary<string, object>(){
                {"stake_address", stakeAddress},
            };
            return await GetArray<AccountDelegationContent>(path, pathParams, query);
        }

        /// <summary>
        /// Obtain information about the registrations and deregistrations of a specific account.
        /// </summary>
        /// <remarks>GET /accounts/{stake_address}/registrations</remarks>
        /// <param name="stakeAddress">Bech32 stake address.</param>
        public async UniTask<AccountRegistrationContent[]> GetAccountRegistrationHistory(string stakeAddress, OrderedListing query = null) {
            const string path = "/accounts/{stake_address}/registrations";
            var pathParams = new Dictionary<string, object>(){
                {"stake_address", stakeAddress},
            };
            return await GetArray<AccountRegistrationContent>(path, pathParams, query);
        }

        /// <summary>
        /// Obtain information about the withdrawals of a specific account.
        /// </summary>
        /// <remarks>GET /accounts/{stake_address}/withdrawals</remarks>
        /// <param name="stakeAddress">Bech32 stake address.</param>
        public async UniTask<AccountWithdrawalContent[]> GetAccountWithdrawalHistory(string stakeAddress, OrderedListing query = null) {
            const string path = "/accounts/{stake_address}/withdrawals";
            var pathParams = new Dictionary<string, object>(){
                {"stake_address", stakeAddress},
            };
            return await GetArray<AccountWithdrawalContent>(path, pathParams, query);
        }

        /// <summary>
        /// Obtain information about the MIRs of a specific account.
        /// </summary>
        /// <remarks>GET /accounts/{stake_address}/mirs</remarks>
        /// <param name="stakeAddress">Bech32 stake address.</param>
        public async UniTask<AccountMirContent[]> GetAccountMIRHistory(string stakeAddress, OrderedListing query = null) {
            const string path = "/accounts/{stake_address}/mirs";
            var pathParams = new Dictionary<string, object>(){
                {"stake_address", stakeAddress},
            };
            return await GetArray<AccountMirContent>(path, pathParams, query);
        }

        /// <summary>
        /// Obtain information about the addresses of a specific account.
        /// </summary>
        /// <remarks>GET /accounts/{stake_address}/addresses</remarks>
        /// <param name="stakeAddress">Bech32 stake address.</param>
        public async UniTask<AccountAddressesContent[]> GetAccountAssociatedAddresses(string stakeAddress, OrderedListing query = null) {
            const string path = "/accounts/{stake_address}/addresses";
            var pathParams = new Dictionary<string, object>(){
                {"stake_address", stakeAddress},
            };
            return await GetArray<AccountAddressesContent>(path, pathParams, query);
        }

        /// <summary>
        /// Obtain information about assets associated with addresses of a specific account.
        /// <b>Be careful</b>, as an account could be part of a mangled address and does not necessarily mean the addresses are owned by user as the account.
        /// </summary>
        /// <remarks>GET /accounts/{stake_address}/addresses/assets</remarks>
        /// <param name="stakeAddress">Bech32 stake address.</param>
        public async UniTask<AccountAddressesAssets[]> GetAssetsAssociatedWithTheAccountAddresses(string stakeAddress, OrderedListing query = null) {
            const string path = "/accounts/{stake_address}/addresses/assets";
            var pathParams = new Dictionary<string, object>(){
                {"stake_address", stakeAddress},
            };
            return await GetArray<AccountAddressesAssets>(path, pathParams, query);
        }

        /// <summary>
        /// Obtain summed details about all addresses associated with a given account.
        /// <b>Be careful</b>, as an account could be part of a mangled address and does not necessarily mean the addresses are owned by user as the account.
        /// </summary>
        /// <remarks>GET /accounts/{stake_address}/addresses/total</remarks>
        /// <param name="stakeAddress">Bech32 address.</param>
        public async UniTask<AccountAddressesTotal> GetDetailedInformationAboutAccountAssociatedAddresses(string stakeAddress) {
            const string path = "/accounts/{stake_address}/addresses/total";
            var pathParams = new Dictionary<string, object>(){
                {"stake_address", stakeAddress},
            };
            return await Get<AccountAddressesTotal>(path, pathParams);
        }

        /// <summary>
        /// List of all used transaction metadata labels.
        /// </summary>
        /// <remarks>GET /metadata/txs/labels</remarks>
        public async UniTask<TxMetadataLabels[]> GetTransactionMetadataLabels(OrderedListing query = null) {
            const string path = "/metadata/txs/labels";
            var pathParams = new Dictionary<string, object>();
            return await GetArray<TxMetadataLabels>(path, pathParams, query);
        }

        /// <summary>
        /// Transaction metadata per label.
        /// </summary>
        /// <remarks>GET /metadata/txs/labels/{label}</remarks>
        /// <param name="label">Metadata label</param>
        public async UniTask<TxMetadataLabelJson[]> GetTransactionMetadataContentInJSON(string label, OrderedListing query = null) {
            const string path = "/metadata/txs/labels/{label}";
            var pathParams = new Dictionary<string, object>(){
                {"label", label},
            };
            return await GetArray<TxMetadataLabelJson>(path, pathParams, query);
        }

        /// <summary>
        /// Transaction metadata per label.
        /// </summary>
        /// <remarks>GET /metadata/txs/labels/{label}/cbor</remarks>
        /// <param name="label">Metadata label</param>
        public async UniTask<TxMetadataLabelCbor[]> GetTransactionMetadataContentInCBOR(string label, OrderedListing query = null) {
            const string path = "/metadata/txs/labels/{label}/cbor";
            var pathParams = new Dictionary<string, object>(){
                {"label", label},
            };
            return await GetArray<TxMetadataLabelCbor>(path, pathParams, query);
        }

        /// <summary>
        /// Obtain information about a specific address.
        /// </summary>
        /// <remarks>GET /addresses/{address}</remarks>
        /// <param name="address">Bech32 address.</param>
        public async UniTask<AddressContent> GetSpecificAddress(string address) {
            const string path = "/addresses/{address}";
            var pathParams = new Dictionary<string, object>(){
                {"address", address},
            };
            return await Get<AddressContent>(path, pathParams);
        }

        /// <summary>
        /// Obtain extended information about a specific address.
        /// </summary>
        /// <remarks>GET /addresses/{address}/extended</remarks>
        /// <param name="address">Bech32 address.</param>
        public async UniTask<AddressContentExtended> GetExtendedInformationOfASpecificAddress(string address) {
            const string path = "/addresses/{address}/extended";
            var pathParams = new Dictionary<string, object>(){
                {"address", address},
            };
            return await Get<AddressContentExtended>(path, pathParams);
        }

        /// <summary>
        /// Obtain details about an address.
        /// </summary>
        /// <remarks>GET /addresses/{address}/total</remarks>
        /// <param name="address">Bech32 address.</param>
        public async UniTask<AddressContentTotal> GetAddressDetails(string address) {
            const string path = "/addresses/{address}/total";
            var pathParams = new Dictionary<string, object>(){
                {"address", address},
            };
            return await Get<AddressContentTotal>(path, pathParams);
        }

        /// <summary>
        /// UTXOs of the address.
        /// </summary>
        /// <remarks>GET /addresses/{address}/utxos</remarks>
        /// <param name="address">Bech32 address.</param>
        public async UniTask<AddressUtxoContent[]> GetAddressUTXOs(string address, OrderedListing query = null) {
            const string path = "/addresses/{address}/utxos";
            var pathParams = new Dictionary<string, object>(){
                {"address", address},
            };
            return await GetArray<AddressUtxoContent>(path, pathParams, query);
        }

        /// <summary>
        /// UTXOs of the address.
        /// </summary>
        /// <remarks>GET /addresses/{address}/utxos/{asset}</remarks>
        /// <param name="address">Bech32 address.</param>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        public async UniTask<AddressUtxoContent[]> GetAddressUTXOsOfAGivenAsset(string address, string asset, OrderedListing query = null) {
            const string path = "/addresses/{address}/utxos/{asset}";
            var pathParams = new Dictionary<string, object>(){
                {"address", address},
                {"asset", asset},
            };
            return await GetArray<AddressUtxoContent>(path, pathParams, query);
        }

        /// <summary>
        /// Transactions on the address.
        /// </summary>
        /// <remarks>GET /addresses/{address}/transactions</remarks>
        /// <param name="address">Bech32 address.</param>
        public async UniTask<AddressTransactionsContent[]> GetAddressTransactions(string address, TargetableOrderedListing query = null) {
            const string path = "/addresses/{address}/transactions";
            var pathParams = new Dictionary<string, object>(){
                {"address", address},
            };
            return await GetArray<AddressTransactionsContent>(path, pathParams, query);
        }

        /// <summary>
        /// List of registered stake pools.
        /// </summary>
        /// <remarks>GET /pools</remarks>
        public async UniTask<string[]> GetListOfStakePools(OrderedListing query = null) {
            const string path = "/pools";
            var pathParams = new Dictionary<string, object>();
            return await GetArray<string>(path, pathParams, query);
        }

        /// <summary>
        /// List of registered stake pools with additional information.
        /// </summary>
        /// <remarks>GET /pools/extended</remarks>
        public async UniTask<PoolListExtended[]> GetListOfStakePoolsWithAdditionalInformation(OrderedListing query = null) {
            const string path = "/pools/extended";
            var pathParams = new Dictionary<string, object>();
            return await GetArray<PoolListExtended>(path, pathParams, query);
        }

        /// <summary>
        /// List of already retired pools.
        /// </summary>
        /// <remarks>GET /pools/retired</remarks>
        public async UniTask<PoolListRetire[]> GetListOfRetiredStakePools(OrderedListing query = null) {
            const string path = "/pools/retired";
            var pathParams = new Dictionary<string, object>();
            return await GetArray<PoolListRetire>(path, pathParams, query);
        }

        /// <summary>
        /// List of stake pools retiring in the upcoming epochs
        /// </summary>
        /// <remarks>GET /pools/retiring</remarks>
        public async UniTask<PoolListRetire[]> GetListOfRetiringStakePools(OrderedListing query = null) {
            const string path = "/pools/retiring";
            var pathParams = new Dictionary<string, object>();
            return await GetArray<PoolListRetire>(path, pathParams, query);
        }

        /// <summary>
        /// Pool information.
        /// </summary>
        /// <remarks>GET /pools/{pool_id}</remarks>
        /// <param name="poolId">Bech32 or hexadecimal pool ID.</param>
        public async UniTask<Pool> GetSpecificStakePool(string poolId) {
            const string path = "/pools/{pool_id}";
            var pathParams = new Dictionary<string, object>(){
                {"pool_id", poolId},
            };
            return await Get<Pool>(path, pathParams);
        }

        /// <summary>
        /// History of stake pool parameters over epochs.
        /// </summary>
        /// <remarks>GET /pools/{pool_id}/history</remarks>
        /// <param name="poolId">Bech32 or hexadecimal pool ID.</param>
        public async UniTask<PoolHistory[]> GetStakePoolHistory(string poolId, OrderedListing query = null) {
            const string path = "/pools/{pool_id}/history";
            var pathParams = new Dictionary<string, object>(){
                {"pool_id", poolId},
            };
            return await GetArray<PoolHistory>(path, pathParams, query);
        }

        /// <summary>
        /// Relays of a stake pool.
        /// </summary>
        /// <remarks>GET /pools/{pool_id}/relays</remarks>
        /// <param name="poolId">Bech32 or hexadecimal pool ID.</param>
        public async UniTask<PoolRelays[]> GetStakePoolRelays(string poolId) {
            const string path = "/pools/{pool_id}/relays";
            var pathParams = new Dictionary<string, object>(){
                {"pool_id", poolId},
            };
            return await GetArray<PoolRelays>(path, pathParams);
        }

        /// <summary>
        /// List of current stake pools delegators.
        /// </summary>
        /// <remarks>GET /pools/{pool_id}/delegators</remarks>
        /// <param name="poolId">Bech32 or hexadecimal pool ID.</param>
        public async UniTask<PoolDelegators[]> GetStakePoolDelegators(string poolId, OrderedListing query = null) {
            const string path = "/pools/{pool_id}/delegators";
            var pathParams = new Dictionary<string, object>(){
                {"pool_id", poolId},
            };
            return await GetArray<PoolDelegators>(path, pathParams, query);
        }

        /// <summary>
        /// List of stake pools blocks.
        /// </summary>
        /// <remarks>GET /pools/{pool_id}/blocks</remarks>
        /// <param name="poolId">Bech32 or hexadecimal pool ID.</param>
        public async UniTask<string[]> GetStakePoolBlocks(string poolId, OrderedListing query = null) {
            const string path = "/pools/{pool_id}/blocks";
            var pathParams = new Dictionary<string, object>(){
                {"pool_id", poolId},
            };
            return await GetArray<string>(path, pathParams, query);
        }

        /// <summary>
        /// List of certificate updates to the stake pool.
        /// </summary>
        /// <remarks>GET /pools/{pool_id}/updates</remarks>
        /// <param name="poolId">Bech32 or hexadecimal pool ID.</param>
        public async UniTask<PoolUpdates[]> GetStakePoolUpdates(string poolId, OrderedListing query = null) {
            const string path = "/pools/{pool_id}/updates";
            var pathParams = new Dictionary<string, object>(){
                {"pool_id", poolId},
            };
            return await GetArray<PoolUpdates>(path, pathParams, query);
        }

        /// <summary>
        /// List of assets.
        /// </summary>
        /// <remarks>GET /assets</remarks>
        public async UniTask<Assets[]> GetAssets(OrderedListing query = null) {
            const string path = "/assets";
            var pathParams = new Dictionary<string, object>();
            return await GetArray<Assets>(path, pathParams, query);
        }

        /// <summary>
        /// Information about a specific asset
        /// </summary>
        /// <remarks>GET /assets/{asset}</remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        public async UniTask<Asset> GetSpecificAsset(string asset) {
            const string path = "/assets/{asset}";
            var pathParams = new Dictionary<string, object>(){
                {"asset", asset},
            };
            return await Get<Asset>(path, pathParams);
        }

        /// <summary>
        /// History of a specific asset
        /// </summary>
        /// <remarks>GET /assets/{asset}/history</remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        public async UniTask<AssetHistory[]> GetAssetHistory(string asset, OrderedListing query = null) {
            const string path = "/assets/{asset}/history";
            var pathParams = new Dictionary<string, object>(){
                {"asset", asset},
            };
            return await GetArray<AssetHistory>(path, pathParams, query);
        }

        /// <summary>
        /// List of a specific asset transactions
        /// </summary>
        /// <remarks>GET /assets/{asset}/transactions</remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        public async UniTask<AssetTransactions[]> GetAssetTransactions(string asset, OrderedListing query = null) {
            const string path = "/assets/{asset}/transactions";
            var pathParams = new Dictionary<string, object>(){
                {"asset", asset},
            };
            return await GetArray<AssetTransactions>(path, pathParams, query);
        }

        /// <summary>
        /// List of a addresses containing a specific asset
        /// </summary>
        /// <remarks>GET /assets/{asset}/addresses</remarks>
        /// <param name="asset">Concatenation of the policy_id and hex-encoded asset_name</param>
        public async UniTask<AssetAddresses[]> GetAssetAddresses(string asset, OrderedListing query = null) {
            const string path = "/assets/{asset}/addresses";
            var pathParams = new Dictionary<string, object>(){
                {"asset", asset},
            };
            return await GetArray<AssetAddresses>(path, pathParams, query);
        }

        /// <summary>
        /// List of asset minted under a specific policy
        /// </summary>
        /// <remarks>GET /assets/policy/{policy_id}</remarks>
        /// <param name="policyId">Specific policy_id</param>
        public async UniTask<AssetPolicy[]> GetAssetsOfASpecificPolicy(string policyId, OrderedListing query = null) {
            const string path = "/assets/policy/{policy_id}";
            var pathParams = new Dictionary<string, object>(){
                {"policy_id", policyId},
            };
            return await GetArray<AssetPolicy>(path, pathParams, query);
        }

        /// <summary>
        /// List of scripts.
        /// </summary>
        /// <remarks>GET /scripts</remarks>
        public async UniTask<Scripts[]> GetScripts(OrderedListing query = null) {
            const string path = "/scripts";
            var pathParams = new Dictionary<string, object>();
            return await GetArray<Scripts>(path, pathParams, query);
        }

        /// <summary>
        /// Information about a specific script
        /// </summary>
        /// <remarks>GET /scripts/{script_hash}</remarks>
        /// <param name="scriptHash">Hash of the script</param>
        public async UniTask<Script> GetSpecificScript(string scriptHash) {
            const string path = "/scripts/{script_hash}";
            var pathParams = new Dictionary<string, object>(){
                {"script_hash", scriptHash},
            };
            return await Get<Script>(path, pathParams);
        }

        /// <summary>
        /// JSON representation of a `timelock` script
        /// </summary>
        /// <remarks>GET /scripts/{script_hash}/json</remarks>
        /// <param name="scriptHash">Hash of the script</param>
        public async UniTask<ScriptJson> GetScriptJSON(string scriptHash) {
            const string path = "/scripts/{script_hash}/json";
            var pathParams = new Dictionary<string, object>(){
                {"script_hash", scriptHash},
            };
            return await Get<ScriptJson>(path, pathParams);
        }

        /// <summary>
        /// CBOR representation of a `plutus` script
        /// </summary>
        /// <remarks>GET /scripts/{script_hash}/cbor</remarks>
        /// <param name="scriptHash">Hash of the script</param>
        public async UniTask<ScriptCbor> GetScriptCBOR(string scriptHash) {
            const string path = "/scripts/{script_hash}/cbor";
            var pathParams = new Dictionary<string, object>(){
                {"script_hash", scriptHash},
            };
            return await Get<ScriptCbor>(path, pathParams);
        }

        /// <summary>
        /// List of redeemers of a specific script
        /// </summary>
        /// <remarks>GET /scripts/{script_hash}/redeemers</remarks>
        /// <param name="scriptHash">Hash of the script</param>
        public async UniTask<ScriptRedeemers[]> GetRedeemersOfASpecificScript(string scriptHash, OrderedListing query = null) {
            const string path = "/scripts/{script_hash}/redeemers";
            var pathParams = new Dictionary<string, object>(){
                {"script_hash", scriptHash},
            };
            return await GetArray<ScriptRedeemers>(path, pathParams, query);
        }

        /// <summary>
        /// Query JSON value of a datum by its hash
        /// </summary>
        /// <remarks>GET /scripts/datum/{datum_hash}</remarks>
        /// <param name="datumHash">Hash of the datum</param>
        public async UniTask<ScriptDatum> GetDatumValue(string datumHash) {
            const string path = "/scripts/datum/{datum_hash}";
            var pathParams = new Dictionary<string, object>(){
                {"datum_hash", datumHash},
            };
            return await Get<ScriptDatum>(path, pathParams);
        }

        /// <summary>
        /// Query CBOR serialised datum by its hash
        /// </summary>
        /// <remarks>GET /scripts/datum/{datum_hash}/cbor</remarks>
        /// <param name="datumHash">Hash of the datum</param>
        public async UniTask<ScriptDatumCbor> GetDatumCBORValue(string datumHash) {
            const string path = "/scripts/datum/{datum_hash}/cbor";
            var pathParams = new Dictionary<string, object>(){
                {"datum_hash", datumHash},
            };
            return await Get<ScriptDatumCbor>(path, pathParams);
        }

        /// <summary>
        /// Derive Shelley address from an xpub
        /// </summary>
        /// <remarks>GET /utils/addresses/xpub/{xpub}/{role}/{index}</remarks>
        /// <param name="xpub">Hex xpub</param>
        /// <param name="role">Account role</param>
        /// <param name="index">Address index</param>
        public async UniTask<UtilsAddressesXpub> GetDeriveAnAddress(string xpub, int role, int index) {
            const string path = "/utils/addresses/xpub/{xpub}/{role}/{index}";
            var pathParams = new Dictionary<string, object>(){
                {"xpub", xpub},
                {"role", role},
                {"index", index},
            };
            return await Get<UtilsAddressesXpub>(path, pathParams);
        }

        /// <summary>
        /// List objects pinned to local storage
        /// </summary>
        /// <remarks>GET /ipfs/pin/list</remarks>
        public async UniTask<ListPinnedObjects[]> GetListPinnedObjects(OrderedListing query = null) {
            const string path = "/ipfs/pin/list";
            var pathParams = new Dictionary<string, object>();
            return await GetArray<ListPinnedObjects>(path, pathParams, query);
        }

        /// <summary>
        /// Get information about locally pinned IPFS object
        /// </summary>
        /// <remarks>GET /ipfs/pin/list/{IPFS_path}</remarks>
        /// <param name="ipfsPath"></param>
        public async UniTask<GetDetailsAboutPinnedObject> GetGetDetailsAboutPinnedObject(string ipfsPath) {
            const string path = "/ipfs/pin/list/{IPFS_path}";
            var pathParams = new Dictionary<string, object>(){
                {"IPFS_path", ipfsPath},
            };
            return await Get<GetDetailsAboutPinnedObject>(path, pathParams);
        }

        /// <summary>
        /// History of your Blockfrost usage metrics in the past 30 days.
        /// </summary>
        /// <remarks>GET /metrics/</remarks>
        public async UniTask<Metrics[]> GetBlockfrostUsageMetrics() {
            const string path = "/metrics/";
            var pathParams = new Dictionary<string, object>();
            return await GetArray<Metrics>(path, pathParams);
        }

        /// <summary>
        /// History of your Blockfrost usage metrics per endpoint in the past 30 days.
        /// </summary>
        /// <remarks>GET /metrics/endpoints</remarks>
        public async UniTask<MetricsEndpoints[]> GetBlockfrostEndpointUsageMetrics() {
            const string path = "/metrics/endpoints";
            var pathParams = new Dictionary<string, object>();
            return await GetArray<MetricsEndpoints>(path, pathParams);
        }

        /// <summary>
        /// Return detailed network information.
        /// </summary>
        /// <remarks>GET /network</remarks>
        public async UniTask<Network> GetNetworkInformation() {
            const string path = "/network";
            var pathParams = new Dictionary<string, object>();
            return await Get<Network>(path, pathParams);
        }

    }
}
