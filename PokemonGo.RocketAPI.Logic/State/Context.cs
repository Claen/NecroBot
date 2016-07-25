
using POGOProtos.Networking.Responses;
using PokemonGo.RocketAPI.Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PokemonGo.RocketAPI.Logic.State
{
    public class Context
    {
        private Client _client;
        private readonly ISettings _clientSettings;
        private LogicClient _logicClient;
        private readonly LogicSettings _logicSettings;
        private Inventory _inventory;
        private Navigation _navigation;
        private readonly Statistics _stats;

        public ISettings Settings { get { return _clientSettings; } }
        public Inventory Inventory {  get { return _inventory; } }
        public Client Client { get { return _client; } }
        public GetPlayerResponse Profile {get;set;}
        public Navigation Navigation { get { return _navigation; } }

        public LogicSettings LogicSettings { get { return _logicSettings; } }
        public LogicClient LogicClient { get { return _logicClient; } }

        public Context(ISettings settings, LogicSettings logicSettings)
        {
            _clientSettings = settings;
            _logicSettings = logicSettings;
            _stats = new Statistics();

            Reset(settings, _logicSettings);
        }

        public void Reset(ISettings settings, LogicSettings logicSettings)
        {
            _client = new Client(_clientSettings);
            _logicClient = new LogicClient(_logicSettings);
            _inventory = new Inventory(_client, _logicClient);
            _navigation = new Navigation(_client);
        }
    }
}
