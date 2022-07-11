using System;

namespace Blockfrost {
    [Serializable]
    public class RootEndpoint {
        public string url;

        public string version;

    }

    [Serializable]
    public class BackendHealthStatus {
        public bool isHealthy { get => is_healthy; }
        public bool is_healthy;

    }

    [Serializable]
    public class CurrentBackendTime {
        public int serverTime { get => server_time; }
        public int server_time;

    }

    [Serializable]
    public class BlockContent {
        /// <summary>
        /// Block creation time in UNIX time
        /// </summary>
        public int time;

        /// <summary>
        /// Block number
        /// </summary>
        public int height;

        /// <summary>
        /// Hash of the block
        /// </summary>
        public string hash;

        /// <summary>
        /// Slot number
        /// </summary>
        public int slot;

        /// <summary>
        /// Epoch number
        /// </summary>
        public int epoch;

        /// <summary>
        /// Slot within the epoch
        /// </summary>
        public int epochSlot { get => epoch_slot; }
        public int epoch_slot;

        /// <summary>
        /// Bech32 ID of the slot leader or specific block description in case there is no slot leader
        /// </summary>
        public string slotLeader { get => slot_leader; }
        public string slot_leader;

        /// <summary>
        /// Block size in Bytes
        /// </summary>
        public int size;

        /// <summary>
        /// Number of transactions in the block
        /// </summary>
        public int txCount { get => tx_count; }
        public int tx_count;

        /// <summary>
        /// Total output within the block in Lovelaces
        /// </summary>
        public string output;

        /// <summary>
        /// Total fees within the block in Lovelaces
        /// </summary>
        public string fees;

        /// <summary>
        /// VRF key of the block
        /// </summary>
        public string blockVrf { get => block_vrf; }
        public string block_vrf;

        /// <summary>
        /// Hash of the previous block
        /// </summary>
        public string previousBlock { get => previous_block; }
        public string previous_block;

        /// <summary>
        /// Hash of the next block
        /// </summary>
        public string nextBlock { get => next_block; }
        public string next_block;

        /// <summary>
        /// Number of block confirmations
        /// </summary>
        public int confirmations;

    }

    [Serializable]
    public class Transactions {
        public string txHash { get => tx_hash; }
        public string tx_hash;

    }

    [Serializable]
    public class BlockContentAddresses {
        /// <summary>
        /// Address that was affected in the specified block
        /// </summary>
        public string address;

        /// <summary>
        /// List of transactions containing the address either in their inputs or outputs. Sorted by transaction index within a block, ascending.
        /// </summary>
        public Transactions[] transactions;

    }

    [Serializable]
    public class GenesisContent {
        /// <summary>
        /// The proportion of slots in which blocks should be issued
        /// </summary>
        public float activeSlotsCoefficient { get => active_slots_coefficient; }
        public float active_slots_coefficient;

        /// <summary>
        /// Determines the quorum needed for votes on the protocol parameter updates
        /// </summary>
        public int updateQuorum { get => update_quorum; }
        public int update_quorum;

        /// <summary>
        /// The total number of lovelace in the system
        /// </summary>
        public string maxLovelaceSupply { get => max_lovelace_supply; }
        public string max_lovelace_supply;

        /// <summary>
        /// Network identifier
        /// </summary>
        public int networkMagic { get => network_magic; }
        public int network_magic;

        /// <summary>
        /// Number of slots in an epoch
        /// </summary>
        public int epochLength { get => epoch_length; }
        public int epoch_length;

        /// <summary>
        /// Time of slot 0 in UNIX time
        /// </summary>
        public int systemStart { get => system_start; }
        public int system_start;

        /// <summary>
        /// Number of slots in an KES period
        /// </summary>
        public int slotsPerKesPeriod { get => slots_per_kes_period; }
        public int slots_per_kes_period;

        /// <summary>
        /// Duration of one slot in seconds
        /// </summary>
        public int slotLength { get => slot_length; }
        public int slot_length;

        /// <summary>
        /// The maximum number of time a KES key can be evolved before a pool operator must create a new operational certificate
        /// </summary>
        public int maxKesEvolutions { get => max_kes_evolutions; }
        public int max_kes_evolutions;

        /// <summary>
        /// Security parameter k
        /// </summary>
        public int securityParam { get => security_param; }
        public int security_param;

    }

    [Serializable]
    public class EpochContent {
        /// <summary>
        /// Epoch number
        /// </summary>
        public int epoch;

        /// <summary>
        /// Unix time of the start of the epoch
        /// </summary>
        public int startTime { get => start_time; }
        public int start_time;

        /// <summary>
        /// Unix time of the end of the epoch
        /// </summary>
        public int endTime { get => end_time; }
        public int end_time;

        /// <summary>
        /// Unix time of the first block of the epoch
        /// </summary>
        public int firstBlockTime { get => first_block_time; }
        public int first_block_time;

        /// <summary>
        /// Unix time of the last block of the epoch
        /// </summary>
        public int lastBlockTime { get => last_block_time; }
        public int last_block_time;

        /// <summary>
        /// Number of blocks within the epoch
        /// </summary>
        public int blockCount { get => block_count; }
        public int block_count;

        /// <summary>
        /// Number of transactions within the epoch
        /// </summary>
        public int txCount { get => tx_count; }
        public int tx_count;

        /// <summary>
        /// Sum of all the transactions within the epoch in Lovelaces
        /// </summary>
        public string output;

        /// <summary>
        /// Sum of all the fees within the epoch in Lovelaces
        /// </summary>
        public string fees;

        /// <summary>
        /// Sum of all the active stakes within the epoch in Lovelaces
        /// </summary>
        public string activeStake { get => active_stake; }
        public string active_stake;

    }

    [Serializable]
    public class ExtraEntropy {
    }

    [Serializable]
    public class EpochParamContent {
        /// <summary>
        /// Epoch number
        /// </summary>
        public int epoch;

        /// <summary>
        /// The linear factor for the minimum fee calculation for given epoch
        /// </summary>
        public int minFeeA { get => min_fee_a; }
        public int min_fee_a;

        /// <summary>
        /// The constant factor for the minimum fee calculation
        /// </summary>
        public int minFeeB { get => min_fee_b; }
        public int min_fee_b;

        /// <summary>
        /// Maximum block body size in Bytes
        /// </summary>
        public int maxBlockSize { get => max_block_size; }
        public int max_block_size;

        /// <summary>
        /// Maximum transaction size
        /// </summary>
        public int maxTxSize { get => max_tx_size; }
        public int max_tx_size;

        /// <summary>
        /// Maximum block header size
        /// </summary>
        public int maxBlockHeaderSize { get => max_block_header_size; }
        public int max_block_header_size;

        /// <summary>
        /// The amount of a key registration deposit in Lovelaces
        /// </summary>
        public string keyDeposit { get => key_deposit; }
        public string key_deposit;

        /// <summary>
        /// The amount of a pool registration deposit in Lovelaces
        /// </summary>
        public string poolDeposit { get => pool_deposit; }
        public string pool_deposit;

        /// <summary>
        /// Epoch bound on pool retirement
        /// </summary>
        public int eMax { get => e_max; }
        public int e_max;

        /// <summary>
        /// Desired number of pools
        /// </summary>
        public int nOpt { get => n_opt; }
        public int n_opt;

        /// <summary>
        /// Pool pledge influence
        /// </summary>
        public float a0;

        /// <summary>
        /// Monetary expansion
        /// </summary>
        public float rho;

        /// <summary>
        /// Treasury expansion
        /// </summary>
        public float tau;

        /// <summary>
        /// Percentage of blocks produced by federated nodes
        /// </summary>
        public float decentralisationParam { get => decentralisation_param; }
        public float decentralisation_param;

        /// <summary>
        /// Seed for extra entropy
        /// </summary>
        public ExtraEntropy extraEntropy { get => extra_entropy; }
        public ExtraEntropy extra_entropy;

        /// <summary>
        /// Accepted protocol major version
        /// </summary>
        public int protocolMajorVer { get => protocol_major_ver; }
        public int protocol_major_ver;

        /// <summary>
        /// Accepted protocol minor version
        /// </summary>
        public int protocolMinorVer { get => protocol_minor_ver; }
        public int protocol_minor_ver;

        /// <summary>
        /// Minimum UTXO value
        /// </summary>
        public string minUtxo { get => min_utxo; }
        public string min_utxo;

        /// <summary>
        /// Minimum stake cost forced on the pool
        /// </summary>
        public string minPoolCost { get => min_pool_cost; }
        public string min_pool_cost;

        /// <summary>
        /// Epoch number only used once
        /// </summary>
        public string nonce;

        /// <summary>
        /// The per word cost of script memory usage
        /// </summary>
        public float priceMem { get => price_mem; }
        public float price_mem;

        /// <summary>
        /// The cost of script execution step usage
        /// </summary>
        public float priceStep { get => price_step; }
        public float price_step;

        /// <summary>
        /// The maximum number of execution memory allowed to be used in a single transaction
        /// </summary>
        public string maxTxExMem { get => max_tx_ex_mem; }
        public string max_tx_ex_mem;

        /// <summary>
        /// The maximum number of execution steps allowed to be used in a single transaction
        /// </summary>
        public string maxTxExSteps { get => max_tx_ex_steps; }
        public string max_tx_ex_steps;

        /// <summary>
        /// The maximum number of execution memory allowed to be used in a single block
        /// </summary>
        public string maxBlockExMem { get => max_block_ex_mem; }
        public string max_block_ex_mem;

        /// <summary>
        /// The maximum number of execution steps allowed to be used in a single block
        /// </summary>
        public string maxBlockExSteps { get => max_block_ex_steps; }
        public string max_block_ex_steps;

        /// <summary>
        /// The maximum Val size
        /// </summary>
        public string maxValSize { get => max_val_size; }
        public string max_val_size;

        /// <summary>
        /// The percentage of the transactions fee which must be provided as collateral when including non-native scripts
        /// </summary>
        public int collateralPercent { get => collateral_percent; }
        public int collateral_percent;

        /// <summary>
        /// The maximum number of collateral inputs allowed in a transaction
        /// </summary>
        public int maxCollateralInputs { get => max_collateral_inputs; }
        public int max_collateral_inputs;

        /// <summary>
        /// Cost per UTxO word for Alonzo. Cost per UTxO byte for Babbage and later.
        /// </summary>
        public string coinsPerUtxoSize { get => coins_per_utxo_size; }
        public string coins_per_utxo_size;

        /// <summary>
        /// Cost per UTxO word for Alonzo. Cost per UTxO byte for Babbage and later.
        /// </summary>
        public string coinsPerUtxoWord { get => coins_per_utxo_word; }
        public string coins_per_utxo_word;

    }

    [Serializable]
    public class OutputAmount {
        /// <summary>
        /// The unit of the value
        /// </summary>
        public string unit;

        /// <summary>
        /// The quantity of the unit
        /// </summary>
        public string quantity;

    }

    [Serializable]
    public class TxContent {
        /// <summary>
        /// Transaction hash
        /// </summary>
        public string hash;

        /// <summary>
        /// Block hash
        /// </summary>
        public string block;

        /// <summary>
        /// Block number
        /// </summary>
        public int blockHeight { get => block_height; }
        public int block_height;

        /// <summary>
        /// Block creation time in UNIX time
        /// </summary>
        public int blockTime { get => block_time; }
        public int block_time;

        /// <summary>
        /// Slot number
        /// </summary>
        public int slot;

        /// <summary>
        /// Transaction index within the block
        /// </summary>
        public int index;

        public OutputAmount[] outputAmount { get => output_amount; }
        public OutputAmount[] output_amount;

        /// <summary>
        /// Fees of the transaction in Lovelaces
        /// </summary>
        public string fees;

        /// <summary>
        /// Deposit within the transaction in Lovelaces
        /// </summary>
        public string deposit;

        /// <summary>
        /// Size of the transaction in Bytes
        /// </summary>
        public int size;

        /// <summary>
        /// Left (included) endpoint of the timelock validity intervals
        /// </summary>
        public string invalidBefore { get => invalid_before; }
        public string invalid_before;

        /// <summary>
        /// Right (excluded) endpoint of the timelock validity intervals
        /// </summary>
        public string invalidHereafter { get => invalid_hereafter; }
        public string invalid_hereafter;

        /// <summary>
        /// Count of UTXOs within the transaction
        /// </summary>
        public int utxoCount { get => utxo_count; }
        public int utxo_count;

        /// <summary>
        /// Count of the withdrawals within the transaction
        /// </summary>
        public int withdrawalCount { get => withdrawal_count; }
        public int withdrawal_count;

        /// <summary>
        /// Count of the MIR certificates within the transaction
        /// </summary>
        public int mirCertCount { get => mir_cert_count; }
        public int mir_cert_count;

        /// <summary>
        /// Count of the delegations within the transaction
        /// </summary>
        public int delegationCount { get => delegation_count; }
        public int delegation_count;

        /// <summary>
        /// Count of the stake keys (de)registration within the transaction
        /// </summary>
        public int stakeCertCount { get => stake_cert_count; }
        public int stake_cert_count;

        /// <summary>
        /// Count of the stake pool registration and update certificates within the transaction
        /// </summary>
        public int poolUpdateCount { get => pool_update_count; }
        public int pool_update_count;

        /// <summary>
        /// Count of the stake pool retirement certificates within the transaction
        /// </summary>
        public int poolRetireCount { get => pool_retire_count; }
        public int pool_retire_count;

        /// <summary>
        /// Count of asset mints and burns within the transaction
        /// </summary>
        public int assetMintOrBurnCount { get => asset_mint_or_burn_count; }
        public int asset_mint_or_burn_count;

        /// <summary>
        /// Count of redeemers within the transaction
        /// </summary>
        public int redeemerCount { get => redeemer_count; }
        public int redeemer_count;

        /// <summary>
        /// True if contract script passed validation
        /// </summary>
        public bool validContract { get => valid_contract; }
        public bool valid_contract;

    }

    [Serializable]
    public class Amount {
        /// <summary>
        /// The unit of the value
        /// </summary>
        public string unit;

        /// <summary>
        /// The quantity of the unit
        /// </summary>
        public string quantity;

    }

    [Serializable]
    public class Inputs {
        /// <summary>
        /// Input address
        /// </summary>
        public string address;

        public Amount[] amount;

        /// <summary>
        /// Hash of the UTXO transaction
        /// </summary>
        public string txHash { get => tx_hash; }
        public string tx_hash;

        /// <summary>
        /// UTXO index in the transaction
        /// </summary>
        public int outputIndex { get => output_index; }
        public int output_index;

        /// <summary>
        /// The hash of the transaction output datum
        /// </summary>
        public string dataHash { get => data_hash; }
        public string data_hash;

        /// <summary>
        /// CBOR encoded inline datum
        /// </summary>
        public string inlineDatum { get => inline_datum; }
        public string inline_datum;

        /// <summary>
        /// The hash of the reference script of the input
        /// </summary>
        public string referenceScriptHash { get => reference_script_hash; }
        public string reference_script_hash;

        /// <summary>
        /// Whether the input is a collateral consumed on script validation failure
        /// </summary>
        public bool collateral;

        /// <summary>
        /// Whether the input is a reference transaction input
        /// </summary>
        public bool reference;

    }

    [Serializable]
    public class Outputs {
        /// <summary>
        /// Output address
        /// </summary>
        public string address;

        public Amount[] amount;

        /// <summary>
        /// UTXO index in the transaction
        /// </summary>
        public int outputIndex { get => output_index; }
        public int output_index;

        /// <summary>
        /// The hash of the transaction output datum
        /// </summary>
        public string dataHash { get => data_hash; }
        public string data_hash;

        /// <summary>
        /// CBOR encoded inline datum
        /// </summary>
        public string inlineDatum { get => inline_datum; }
        public string inline_datum;

        /// <summary>
        /// The hash of the reference script of the output
        /// </summary>
        public string referenceScriptHash { get => reference_script_hash; }
        public string reference_script_hash;

    }

    [Serializable]
    public class TxContentUtxo {
        /// <summary>
        /// Transaction hash
        /// </summary>
        public string hash;

        public Inputs[] inputs;

        public Outputs[] outputs;

    }

    [Serializable]
    public class TxContentStakeAddr {
        /// <summary>
        /// Index of the certificate within the transaction
        /// </summary>
        public int certIndex { get => cert_index; }
        public int cert_index;

        /// <summary>
        /// Delegation stake address
        /// </summary>
        public string address;

        /// <summary>
        /// Registration boolean, false if deregistration
        /// </summary>
        public bool registration;

    }

    [Serializable]
    public class TxContentDelegations {
        /// <summary>
        /// Index of the certificate within the transaction
        /// </summary>
        public int index;

        /// <summary>
        /// Index of the certificate within the transaction
        /// </summary>
        public int certIndex { get => cert_index; }
        public int cert_index;

        /// <summary>
        /// Bech32 delegation stake address
        /// </summary>
        public string address;

        /// <summary>
        /// Bech32 ID of delegated stake pool
        /// </summary>
        public string poolId { get => pool_id; }
        public string pool_id;

        /// <summary>
        /// Epoch in which the delegation becomes active
        /// </summary>
        public int activeEpoch { get => active_epoch; }
        public int active_epoch;

    }

    [Serializable]
    public class TxContentWithdrawals {
        /// <summary>
        /// Bech32 withdrawal address
        /// </summary>
        public string address;

        /// <summary>
        /// Withdrawal amount in Lovelaces
        /// </summary>
        public string amount;

    }

    [Serializable]
    public class TxContentMirs {
        /// <summary>
        /// Source of MIR funds
        /// </summary>
        public string pot;

        /// <summary>
        /// Index of the certificate within the transaction
        /// </summary>
        public int certIndex { get => cert_index; }
        public int cert_index;

        /// <summary>
        /// Bech32 stake address
        /// </summary>
        public string address;

        /// <summary>
        /// MIR amount in Lovelaces
        /// </summary>
        public string amount;

    }

    [Serializable]
    public class Metadata {
        /// <summary>
        /// URL to the stake pool metadata
        /// </summary>
        public string url;

        /// <summary>
        /// Hash of the metadata file
        /// </summary>
        public string hash;

        /// <summary>
        /// Ticker of the stake pool
        /// </summary>
        public string ticker;

        /// <summary>
        /// Name of the stake pool
        /// </summary>
        public string name;

        /// <summary>
        /// Description of the stake pool
        /// </summary>
        public string description;

        /// <summary>
        /// Home page of the stake pool
        /// </summary>
        public string homepage;

    }

    [Serializable]
    public class Relays {
        /// <summary>
        /// IPv4 address of the relay
        /// </summary>
        public string ipv4;

        /// <summary>
        /// IPv6 address of the relay
        /// </summary>
        public string ipv6;

        /// <summary>
        /// DNS name of the relay
        /// </summary>
        public string dns;

        /// <summary>
        /// DNS SRV entry of the relay
        /// </summary>
        public string dnsSrv { get => dns_srv; }
        public string dns_srv;

        /// <summary>
        /// Network port of the relay
        /// </summary>
        public int port;

    }

    [Serializable]
    public class TxContentPoolCerts {
        /// <summary>
        /// Index of the certificate within the transaction
        /// </summary>
        public int certIndex { get => cert_index; }
        public int cert_index;

        /// <summary>
        /// Bech32 encoded pool ID
        /// </summary>
        public string poolId { get => pool_id; }
        public string pool_id;

        /// <summary>
        /// VRF key hash
        /// </summary>
        public string vrfKey { get => vrf_key; }
        public string vrf_key;

        /// <summary>
        /// Stake pool certificate pledge in Lovelaces
        /// </summary>
        public string pledge;

        /// <summary>
        /// Margin tax cost of the stake pool
        /// </summary>
        public float marginCost { get => margin_cost; }
        public float margin_cost;

        /// <summary>
        /// Fixed tax cost of the stake pool in Lovelaces
        /// </summary>
        public string fixedCost { get => fixed_cost; }
        public string fixed_cost;

        /// <summary>
        /// Bech32 reward account of the stake pool
        /// </summary>
        public string rewardAccount { get => reward_account; }
        public string reward_account;

        public string[] owners;

        public Metadata metadata;

        public Relays[] relays;

        /// <summary>
        /// Epoch in which the update becomes active
        /// </summary>
        public int activeEpoch { get => active_epoch; }
        public int active_epoch;

    }

    [Serializable]
    public class TxContentPoolRetires {
        /// <summary>
        /// Index of the certificate within the transaction
        /// </summary>
        public int certIndex { get => cert_index; }
        public int cert_index;

        /// <summary>
        /// Bech32 stake pool ID
        /// </summary>
        public string poolId { get => pool_id; }
        public string pool_id;

        /// <summary>
        /// Epoch in which the pool becomes retired
        /// </summary>
        public int retiringEpoch { get => retiring_epoch; }
        public int retiring_epoch;

    }

    [Serializable]
    public class TxContentMetadata {
        /// <summary>
        /// Metadata label
        /// </summary>
        public string label;

    }

    [Serializable]
    public class TxContentMetadataCbor {
        /// <summary>
        /// Metadata label
        /// </summary>
        public string label;

        /// <summary>
        /// Content of the CBOR metadata
        /// </summary>
        public string cborMetadata { get => cbor_metadata; }
        public string cbor_metadata;

        /// <summary>
        /// Content of the CBOR metadata in hex
        /// </summary>
        public string metadata;

    }

    [Serializable]
    public class TxContentRedeemers {
        /// <summary>
        /// Index of the redeemer within the transaction
        /// </summary>
        public int txIndex { get => tx_index; }
        public int tx_index;

        /// <summary>
        /// Validation purpose
        /// </summary>
        public string purpose;

        /// <summary>
        /// Script hash
        /// </summary>
        public string scriptHash { get => script_hash; }
        public string script_hash;

        /// <summary>
        /// Redeemer data hash
        /// </summary>
        public string redeemerDataHash { get => redeemer_data_hash; }
        public string redeemer_data_hash;

        /// <summary>
        /// Datum hash
        /// </summary>
        public string datumHash { get => datum_hash; }
        public string datum_hash;

        /// <summary>
        /// The budget in Memory to run a script
        /// </summary>
        public string unitMem { get => unit_mem; }
        public string unit_mem;

        /// <summary>
        /// The budget in CPU steps to run a script
        /// </summary>
        public string unitSteps { get => unit_steps; }
        public string unit_steps;

        /// <summary>
        /// The fee consumed to run the script
        /// </summary>
        public string fee;

    }

    [Serializable]
    public class AccountContent {
        /// <summary>
        /// Bech32 stake address
        /// </summary>
        public string stakeAddress { get => stake_address; }
        public string stake_address;

        /// <summary>
        /// Registration state of an account
        /// </summary>
        public bool active;

        /// <summary>
        /// Epoch of the most recent action - registration or deregistration
        /// </summary>
        public int activeEpoch { get => active_epoch; }
        public int active_epoch;

        /// <summary>
        /// Balance of the account in Lovelaces
        /// </summary>
        public string controlledAmount { get => controlled_amount; }
        public string controlled_amount;

        /// <summary>
        /// Sum of all rewards for the account in the Lovelaces
        /// </summary>
        public string rewardsSum { get => rewards_sum; }
        public string rewards_sum;

        /// <summary>
        /// Sum of all the withdrawals for the account in Lovelaces
        /// </summary>
        public string withdrawalsSum { get => withdrawals_sum; }
        public string withdrawals_sum;

        /// <summary>
        /// Sum of all  funds from reserves for the account in the Lovelaces
        /// </summary>
        public string reservesSum { get => reserves_sum; }
        public string reserves_sum;

        /// <summary>
        /// Sum of all funds from treasury for the account in the Lovelaces
        /// </summary>
        public string treasurySum { get => treasury_sum; }
        public string treasury_sum;

        /// <summary>
        /// Sum of available rewards that haven't been withdrawn yet for the account in the Lovelaces
        /// </summary>
        public string withdrawableAmount { get => withdrawable_amount; }
        public string withdrawable_amount;

        /// <summary>
        /// Bech32 pool ID that owns the account
        /// </summary>
        public string poolId { get => pool_id; }
        public string pool_id;

    }

    [Serializable]
    public class AccountRewardContent {
        /// <summary>
        /// Epoch of the associated reward
        /// </summary>
        public int epoch;

        /// <summary>
        /// Rewards for given epoch in Lovelaces
        /// </summary>
        public string amount;

        /// <summary>
        /// Bech32 pool ID being delegated to
        /// </summary>
        public string poolId { get => pool_id; }
        public string pool_id;

        /// <summary>
        /// Type of the reward
        /// </summary>
        public string type;

    }

    [Serializable]
    public class AccountHistoryContent {
        /// <summary>
        /// Epoch in which the stake was active
        /// </summary>
        public int activeEpoch { get => active_epoch; }
        public int active_epoch;

        /// <summary>
        /// Stake amount in Lovelaces
        /// </summary>
        public string amount;

        /// <summary>
        /// Bech32 ID of pool being delegated to
        /// </summary>
        public string poolId { get => pool_id; }
        public string pool_id;

    }

    [Serializable]
    public class AccountDelegationContent {
        /// <summary>
        /// Epoch in which the delegation becomes active
        /// </summary>
        public int activeEpoch { get => active_epoch; }
        public int active_epoch;

        /// <summary>
        /// Hash of the transaction containing the delegation
        /// </summary>
        public string txHash { get => tx_hash; }
        public string tx_hash;

        /// <summary>
        /// Rewards for given epoch in Lovelaces
        /// </summary>
        public string amount;

        /// <summary>
        /// Bech32 ID of pool being delegated to
        /// </summary>
        public string poolId { get => pool_id; }
        public string pool_id;

    }

    [Serializable]
    public class AccountRegistrationContent {
        /// <summary>
        /// Hash of the transaction containing the (de)registration certificate
        /// </summary>
        public string txHash { get => tx_hash; }
        public string tx_hash;

        /// <summary>
        /// Action in the certificate
        /// </summary>
        public string action;

    }

    [Serializable]
    public class AccountWithdrawalContent {
        /// <summary>
        /// Hash of the transaction containing the withdrawal
        /// </summary>
        public string txHash { get => tx_hash; }
        public string tx_hash;

        /// <summary>
        /// Withdrawal amount in Lovelaces
        /// </summary>
        public string amount;

    }

    [Serializable]
    public class AccountMirContent {
        /// <summary>
        /// Hash of the transaction containing the MIR
        /// </summary>
        public string txHash { get => tx_hash; }
        public string tx_hash;

        /// <summary>
        /// MIR amount in Lovelaces
        /// </summary>
        public string amount;

    }

    [Serializable]
    public class AccountAddressesContent {
        /// <summary>
        /// Address associated with the stake key
        /// </summary>
        public string address;

    }

    [Serializable]
    public class AccountAddressesAssets {
        /// <summary>
        /// The unit of the value
        /// </summary>
        public string unit;

        /// <summary>
        /// The quantity of the unit
        /// </summary>
        public string quantity;

    }

    [Serializable]
    public class ReceivedSum {
        /// <summary>
        /// The unit of the value
        /// </summary>
        public string unit;

        /// <summary>
        /// The quantity of the unit
        /// </summary>
        public string quantity;

    }

    [Serializable]
    public class SentSum {
        /// <summary>
        /// The unit of the value
        /// </summary>
        public string unit;

        /// <summary>
        /// The quantity of the unit
        /// </summary>
        public string quantity;

    }

    [Serializable]
    public class AccountAddressesTotal {
        /// <summary>
        /// Bech32 encoded stake address
        /// </summary>
        public string stakeAddress { get => stake_address; }
        public string stake_address;

        public ReceivedSum[] receivedSum { get => received_sum; }
        public ReceivedSum[] received_sum;

        public SentSum[] sentSum { get => sent_sum; }
        public SentSum[] sent_sum;

        /// <summary>
        /// Count of all transactions for all addresses associated with the account
        /// </summary>
        public int txCount { get => tx_count; }
        public int tx_count;

    }

    [Serializable]
    public class TxMetadataLabels {
        /// <summary>
        /// Metadata label
        /// </summary>
        public string label;

        /// <summary>
        /// CIP10 defined description
        /// </summary>
        public string cip10;

        /// <summary>
        /// The count of metadata entries with a specific label
        /// </summary>
        public string count;

    }

    [Serializable]
    public class TxMetadataLabelJson {
        /// <summary>
        /// Transaction hash that contains the specific metadata
        /// </summary>
        public string txHash { get => tx_hash; }
        public string tx_hash;

    }

    [Serializable]
    public class TxMetadataLabelCbor {
        /// <summary>
        /// Transaction hash that contains the specific metadata
        /// </summary>
        public string txHash { get => tx_hash; }
        public string tx_hash;

        /// <summary>
        /// Content of the CBOR metadata
        /// </summary>
        public string cborMetadata { get => cbor_metadata; }
        public string cbor_metadata;

        /// <summary>
        /// Content of the CBOR metadata in hex
        /// </summary>
        public string metadata;

    }

    [Serializable]
    public class AddressContent {
        /// <summary>
        /// Bech32 encoded addresses
        /// </summary>
        public string address;

        public Amount[] amount;

        /// <summary>
        /// Stake address that controls the key
        /// </summary>
        public string stakeAddress { get => stake_address; }
        public string stake_address;

        /// <summary>
        /// Address era
        /// </summary>
        public string type;

        /// <summary>
        /// True if this is a script address
        /// </summary>
        public bool script;

    }

    [Serializable]
    public class AddressContentExtended {
        /// <summary>
        /// Bech32 encoded addresses
        /// </summary>
        public string address;

        public Amount[] amount;

        /// <summary>
        /// Stake address that controls the key
        /// </summary>
        public string stakeAddress { get => stake_address; }
        public string stake_address;

        /// <summary>
        /// Address era
        /// </summary>
        public string type;

        /// <summary>
        /// True if this is a script address
        /// </summary>
        public bool script;

    }

    [Serializable]
    public class AddressContentTotal {
        /// <summary>
        /// Bech32 encoded address
        /// </summary>
        public string address;

        public ReceivedSum[] receivedSum { get => received_sum; }
        public ReceivedSum[] received_sum;

        public SentSum[] sentSum { get => sent_sum; }
        public SentSum[] sent_sum;

        /// <summary>
        /// Count of all transactions on the address
        /// </summary>
        public int txCount { get => tx_count; }
        public int tx_count;

    }

    [Serializable]
    public class AddressUtxoContent {
        /// <summary>
        /// Transaction hash of the UTXO
        /// </summary>
        public string txHash { get => tx_hash; }
        public string tx_hash;

        /// <summary>
        /// UTXO index in the transaction
        /// </summary>
        public int txIndex { get => tx_index; }
        public int tx_index;

        /// <summary>
        /// UTXO index in the transaction
        /// </summary>
        public int outputIndex { get => output_index; }
        public int output_index;

        public Amount[] amount;

        /// <summary>
        /// Block hash of the UTXO
        /// </summary>
        public string block;

        /// <summary>
        /// The hash of the transaction output datum
        /// </summary>
        public string dataHash { get => data_hash; }
        public string data_hash;

        /// <summary>
        /// CBOR encoded inline datum
        /// </summary>
        public string inlineDatum { get => inline_datum; }
        public string inline_datum;

        /// <summary>
        /// The hash of the reference script of the output
        /// </summary>
        public string referenceScriptHash { get => reference_script_hash; }
        public string reference_script_hash;

    }

    [Serializable]
    public class AddressTransactionsContent {
        /// <summary>
        /// Hash of the transaction
        /// </summary>
        public string txHash { get => tx_hash; }
        public string tx_hash;

        /// <summary>
        /// Transaction index within the block
        /// </summary>
        public int txIndex { get => tx_index; }
        public int tx_index;

        /// <summary>
        /// Block height
        /// </summary>
        public int blockHeight { get => block_height; }
        public int block_height;

        /// <summary>
        /// Block creation time in UNIX time
        /// </summary>
        public int blockTime { get => block_time; }
        public int block_time;

    }

    [Serializable]
    public class PoolListExtended {
        /// <summary>
        /// Bech32 encoded pool ID
        /// </summary>
        public string poolId { get => pool_id; }
        public string pool_id;

        /// <summary>
        /// Hexadecimal pool ID.
        /// </summary>
        public string hex;

        /// <summary>
        /// Active delegated amount
        /// </summary>
        public string activeStake { get => active_stake; }
        public string active_stake;

        /// <summary>
        /// Currently delegated amount
        /// </summary>
        public string liveStake { get => live_stake; }
        public string live_stake;

    }

    [Serializable]
    public class PoolListRetire {
        /// <summary>
        /// Bech32 encoded pool ID
        /// </summary>
        public string poolId { get => pool_id; }
        public string pool_id;

        /// <summary>
        /// Retirement epoch number
        /// </summary>
        public int epoch;

    }

    [Serializable]
    public class Pool {
        /// <summary>
        /// Bech32 pool ID
        /// </summary>
        public string poolId { get => pool_id; }
        public string pool_id;

        /// <summary>
        /// Hexadecimal pool ID.
        /// </summary>
        public string hex;

        /// <summary>
        /// VRF key hash
        /// </summary>
        public string vrfKey { get => vrf_key; }
        public string vrf_key;

        /// <summary>
        /// Total minted blocks
        /// </summary>
        public int blocksMinted { get => blocks_minted; }
        public int blocks_minted;

        /// <summary>
        /// Number of blocks minted in the current epoch
        /// </summary>
        public int blocksEpoch { get => blocks_epoch; }
        public int blocks_epoch;

        public string liveStake { get => live_stake; }
        public string live_stake;

        public float liveSize { get => live_size; }
        public float live_size;

        public float liveSaturation { get => live_saturation; }
        public float live_saturation;

        public float liveDelegators { get => live_delegators; }
        public float live_delegators;

        public string activeStake { get => active_stake; }
        public string active_stake;

        public float activeSize { get => active_size; }
        public float active_size;

        /// <summary>
        /// Stake pool certificate pledge
        /// </summary>
        public string declaredPledge { get => declared_pledge; }
        public string declared_pledge;

        /// <summary>
        /// Stake pool current pledge
        /// </summary>
        public string livePledge { get => live_pledge; }
        public string live_pledge;

        /// <summary>
        /// Margin tax cost of the stake pool
        /// </summary>
        public float marginCost { get => margin_cost; }
        public float margin_cost;

        /// <summary>
        /// Fixed tax cost of the stake pool
        /// </summary>
        public string fixedCost { get => fixed_cost; }
        public string fixed_cost;

        /// <summary>
        /// Bech32 reward account of the stake pool
        /// </summary>
        public string rewardAccount { get => reward_account; }
        public string reward_account;

        public string[] owners;

        public string[] registration;

        public string[] retirement;

    }

    [Serializable]
    public class PoolHistory {
        /// <summary>
        /// Epoch number
        /// </summary>
        public int epoch;

        /// <summary>
        /// Number of blocks created by pool
        /// </summary>
        public int blocks;

        /// <summary>
        /// Active (Snapshot of live stake 2 epochs ago) stake in Lovelaces
        /// </summary>
        public string activeStake { get => active_stake; }
        public string active_stake;

        /// <summary>
        /// Pool size (percentage) of overall active stake at that epoch
        /// </summary>
        public float activeSize { get => active_size; }
        public float active_size;

        /// <summary>
        /// Number of delegators for epoch
        /// </summary>
        public int delegatorsCount { get => delegators_count; }
        public int delegators_count;

        /// <summary>
        /// Total rewards received before distribution to delegators
        /// </summary>
        public string rewards;

        /// <summary>
        /// Pool operator rewards
        /// </summary>
        public string fees;

    }

    [Serializable]
    public class PoolRelays {
        /// <summary>
        /// IPv4 address of the relay
        /// </summary>
        public string ipv4;

        /// <summary>
        /// IPv6 address of the relay
        /// </summary>
        public string ipv6;

        /// <summary>
        /// DNS name of the relay
        /// </summary>
        public string dns;

        /// <summary>
        /// DNS SRV entry of the relay
        /// </summary>
        public string dnsSrv { get => dns_srv; }
        public string dns_srv;

        /// <summary>
        /// Network port of the relay
        /// </summary>
        public int port;

    }

    [Serializable]
    public class PoolDelegators {
        /// <summary>
        /// Bech32 encoded stake addresses
        /// </summary>
        public string address;

        /// <summary>
        /// Currently delegated amount
        /// </summary>
        public string liveStake { get => live_stake; }
        public string live_stake;

    }

    [Serializable]
    public class PoolUpdates {
        /// <summary>
        /// Transaction ID
        /// </summary>
        public string txHash { get => tx_hash; }
        public string tx_hash;

        /// <summary>
        /// Certificate within the transaction
        /// </summary>
        public int certIndex { get => cert_index; }
        public int cert_index;

        /// <summary>
        /// Action in the certificate
        /// </summary>
        public string action;

    }

    [Serializable]
    public class Assets {
        /// <summary>
        /// Asset identifier
        /// </summary>
        public string asset;

        /// <summary>
        /// Current asset quantity
        /// </summary>
        public string quantity;

    }

    [Serializable]
    public class OnchainMetadata {
        /// <summary>
        /// Name of the asset
        /// </summary>
        public string name;

    }

    [Serializable]
    public class Asset {
        /// <summary>
        /// Hex-encoded asset full name
        /// </summary>
        public string asset;

        /// <summary>
        /// Policy ID of the asset
        /// </summary>
        public string policyId { get => policy_id; }
        public string policy_id;

        /// <summary>
        /// Hex-encoded asset name of the asset
        /// </summary>
        public string assetName { get => asset_name; }
        public string asset_name;

        /// <summary>
        /// CIP14 based user-facing fingerprint
        /// </summary>
        public string fingerprint;

        /// <summary>
        /// Current asset quantity
        /// </summary>
        public string quantity;

        /// <summary>
        /// ID of the initial minting transaction
        /// </summary>
        public string initialMintTxHash { get => initial_mint_tx_hash; }
        public string initial_mint_tx_hash;

        /// <summary>
        /// Count of mint and burn transactions
        /// </summary>
        public int mintOrBurnCount { get => mint_or_burn_count; }
        public int mint_or_burn_count;

        /// <summary>
        /// On-chain metadata stored in the minting transaction under label 721,
        /// community discussion around the standard ongoing at https://github.com/cardano-foundation/CIPs/pull/85
        /// </summary>
        public OnchainMetadata onchainMetadata { get => onchain_metadata; }
        public OnchainMetadata onchain_metadata;

        public Metadata metadata;

    }

    [Serializable]
    public class AssetHistory {
        /// <summary>
        /// Hash of the transaction containing the asset action
        /// </summary>
        public string txHash { get => tx_hash; }
        public string tx_hash;

        /// <summary>
        /// Action executed upon the asset policy
        /// </summary>
        public string action;

        /// <summary>
        /// Asset amount of the specific action
        /// </summary>
        public string amount;

    }

    [Serializable]
    public class AssetTransactions {
        /// <summary>
        /// Hash of the transaction
        /// </summary>
        public string txHash { get => tx_hash; }
        public string tx_hash;

        /// <summary>
        /// Transaction index within the block
        /// </summary>
        public int txIndex { get => tx_index; }
        public int tx_index;

        /// <summary>
        /// Block height
        /// </summary>
        public int blockHeight { get => block_height; }
        public int block_height;

    }

    [Serializable]
    public class AssetAddresses {
        /// <summary>
        /// Address containing the specific asset
        /// </summary>
        public string address;

        /// <summary>
        /// Asset quantity on the specific address
        /// </summary>
        public string quantity;

    }

    [Serializable]
    public class AssetPolicy {
        /// <summary>
        /// Concatenation of the policy_id and hex-encoded asset_name
        /// </summary>
        public string asset;

        /// <summary>
        /// Current asset quantity
        /// </summary>
        public string quantity;

    }

    [Serializable]
    public class Scripts {
        /// <summary>
        /// Script hash
        /// </summary>
        public string scriptHash { get => script_hash; }
        public string script_hash;

    }

    [Serializable]
    public class Script {
        /// <summary>
        /// Script hash
        /// </summary>
        public string scriptHash { get => script_hash; }
        public string script_hash;

        /// <summary>
        /// Type of the script language
        /// </summary>
        public string type;

        /// <summary>
        /// The size of the CBOR serialised script, if a Plutus script
        /// </summary>
        public int serialisedSize { get => serialised_size; }
        public int serialised_size;

    }

    [Serializable]
    public class ScriptJson {
    }

    [Serializable]
    public class ScriptCbor {
        /// <summary>
        /// CBOR contents of the `plutus` script, null for `timelocks`
        /// </summary>
        public string cbor;

    }

    [Serializable]
    public class ScriptRedeemers {
        /// <summary>
        /// Hash of the transaction
        /// </summary>
        public string txHash { get => tx_hash; }
        public string tx_hash;

        /// <summary>
        /// The index of the redeemer pointer in the transaction
        /// </summary>
        public int txIndex { get => tx_index; }
        public int tx_index;

        /// <summary>
        /// Validation purpose
        /// </summary>
        public string purpose;

        /// <summary>
        /// Datum hash of the redeemer
        /// </summary>
        public string redeemerDataHash { get => redeemer_data_hash; }
        public string redeemer_data_hash;

        /// <summary>
        /// Datum hash
        /// </summary>
        public string datumHash { get => datum_hash; }
        public string datum_hash;

        /// <summary>
        /// The budget in Memory to run a script
        /// </summary>
        public string unitMem { get => unit_mem; }
        public string unit_mem;

        /// <summary>
        /// The budget in CPU steps to run a script
        /// </summary>
        public string unitSteps { get => unit_steps; }
        public string unit_steps;

        /// <summary>
        /// The fee consumed to run the script
        /// </summary>
        public string fee;

    }

    [Serializable]
    public class ScriptDatum {
    }

    [Serializable]
    public class ScriptDatumCbor {
        /// <summary>
        /// CBOR serialized datum
        /// </summary>
        public string cbor;

    }

    [Serializable]
    public class UtilsAddressesXpub {
        /// <summary>
        /// Script hash
        /// </summary>
        public string xpub;

        /// <summary>
        /// Account role
        /// </summary>
        public int role;

        /// <summary>
        /// Address index
        /// </summary>
        public int index;

        /// <summary>
        /// Derived address
        /// </summary>
        public string address;

    }

    [Serializable]
    public class SubmitATransactionForExecutionUnitsEvaluation {
    }

    [Serializable]
    public class AddAFileToIPFS {
        /// <summary>
        /// Name of the file
        /// </summary>
        public string name;

        /// <summary>
        /// IPFS hash of the file
        /// </summary>
        public string ipfsHash { get => ipfs_hash; }
        public string ipfs_hash;

        /// <summary>
        /// IPFS node size in Bytes
        /// </summary>
        public string size;

    }

    [Serializable]
    public class PinAnObject {
        /// <summary>
        /// IPFS hash of the pinned object
        /// </summary>
        public string ipfsHash { get => ipfs_hash; }
        public string ipfs_hash;

        /// <summary>
        /// State of the pin action
        /// </summary>
        public string state;

    }

    [Serializable]
    public class ListPinnedObjects {
        /// <summary>
        /// Creation time of the IPFS object on our backends
        /// </summary>
        public int timeCreated { get => time_created; }
        public int time_created;

        /// <summary>
        /// Pin time of the IPFS object on our backends
        /// </summary>
        public int timePinned { get => time_pinned; }
        public int time_pinned;

        /// <summary>
        /// IPFS hash of the pinned object
        /// </summary>
        public string ipfsHash { get => ipfs_hash; }
        public string ipfs_hash;

        /// <summary>
        /// Size of the object in Bytes
        /// </summary>
        public string size;

        /// <summary>
        /// State of the pinned object, which is `queued` when we are retriving object. If this
        /// is successful the state is changed to `pinned` or `failed` if not. The state `gc` means the
        /// pinned item has been garbage collected due to account being over storage quota or after it has
        /// been moved to `unpinned` state by removing the object pin.
        /// </summary>
        public string state;

    }

    [Serializable]
    public class GetDetailsAboutPinnedObject {
        /// <summary>
        /// Time of the creation of the IPFS object on our backends
        /// </summary>
        public int timeCreated { get => time_created; }
        public int time_created;

        /// <summary>
        /// Time of the pin of the IPFS object on our backends
        /// </summary>
        public int timePinned { get => time_pinned; }
        public int time_pinned;

        /// <summary>
        /// IPFS hash of the pinned object
        /// </summary>
        public string ipfsHash { get => ipfs_hash; }
        public string ipfs_hash;

        /// <summary>
        /// Size of the object in Bytes
        /// </summary>
        public string size;

        /// <summary>
        /// State of the pinned object. We define 5 states: `queued`, `pinned`, `unpinned`, `failed`, `gc`.
        /// When the object is pending retrieval (i.e. after `/ipfs/pin/add/{IPFS_path}`), the state is `queued`.
        /// If the object is already successfully retrieved, state is changed to `pinned` or `failed` otherwise.
        /// When object is unpinned (i.e. after `/ipfs/pin/remove/{IPFS_path}`) it is marked for garbage collection.
        /// State `gc` means that a previously `unpinned` item has been garbage collected due to account being over storage quota.
        /// </summary>
        public string state;

    }

    [Serializable]
    public class Metrics {
        /// <summary>
        /// Starting time of the call count interval (ends midnight UTC) in UNIX time
        /// </summary>
        public int time;

        /// <summary>
        /// Sum of all calls for a particular day
        /// </summary>
        public int calls;

    }

    [Serializable]
    public class MetricsEndpoints {
        /// <summary>
        /// Starting time of the call count interval (ends midnight UTC) in UNIX time
        /// </summary>
        public int time;

        /// <summary>
        /// Sum of all calls for a particular day and endpoint
        /// </summary>
        public int calls;

        /// <summary>
        /// Endpoint parent name
        /// </summary>
        public string endpoint;

    }

    [Serializable]
    public class Supply {
        /// <summary>
        /// Maximum supply in Lovelaces
        /// </summary>
        public string max;

        /// <summary>
        /// Current total (max supply - reserves) supply in Lovelaces
        /// </summary>
        public string total;

        /// <summary>
        /// Current circulating (UTXOs + withdrawables) supply in Lovelaces
        /// </summary>
        public string circulating;

        /// <summary>
        /// Current supply locked by scripts in Lovelaces
        /// </summary>
        public string locked;

        /// <summary>
        /// Current supply locked in treasury
        /// </summary>
        public string treasury;

        /// <summary>
        /// Current supply locked in reserves
        /// </summary>
        public string reserves;

    }

    [Serializable]
    public class Stake {
        /// <summary>
        /// Current live stake in Lovelaces
        /// </summary>
        public string live;

        /// <summary>
        /// Current active stake in Lovelaces
        /// </summary>
        public string active;

    }

    [Serializable]
    public class Network {
        public Supply supply;

        public Stake stake;

    }

    [Serializable]
    public class NutlinkAddress {
        /// <summary>
        /// Bech32 encoded address
        /// </summary>
        public string address;

        /// <summary>
        /// URL of the specific metadata file
        /// </summary>
        public string metadataUrl { get => metadata_url; }
        public string metadata_url;

        /// <summary>
        /// Hash of the metadata file
        /// </summary>
        public string metadataHash { get => metadata_hash; }
        public string metadata_hash;

        /// <summary>
        /// The cached metadata of the `metadata_url` file.
        /// </summary>
        public Metadata metadata;

    }

    [Serializable]
    public class NutlinkAddressTickers {
        /// <summary>
        /// Name of the ticker
        /// </summary>
        public string name;

        /// <summary>
        /// Number of ticker records
        /// </summary>
        public int count;

        /// <summary>
        /// Block height of the latest record
        /// </summary>
        public int latestBlock { get => latest_block; }
        public int latest_block;

    }

    [Serializable]
    public class NutlinkAddressTicker {
        /// <summary>
        /// Hash of the transaction
        /// </summary>
        public string txHash { get => tx_hash; }
        public string tx_hash;

        /// <summary>
        /// Block height of the record
        /// </summary>
        public int blockHeight { get => block_height; }
        public int block_height;

        /// <summary>
        /// Transaction index within the block
        /// </summary>
        public int txIndex { get => tx_index; }
        public int tx_index;

    }

    [Serializable]
    public class NutlinkTickersTicker {
        /// <summary>
        /// Address of a metadata oracle
        /// </summary>
        public string address;

        /// <summary>
        /// Hash of the transaction
        /// </summary>
        public string txHash { get => tx_hash; }
        public string tx_hash;

        /// <summary>
        /// Block height of the record
        /// </summary>
        public int blockHeight { get => block_height; }
        public int block_height;

        /// <summary>
        /// Transaction index within the block
        /// </summary>
        public int txIndex { get => tx_index; }
        public int tx_index;

    }

}
