using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileValidator
{
    public class ActiveUpdater
    {
        IVersionProvider _currentVersionProvider;
        IVersionProvider _serverVersionProvider;
        IUpdateResolver _updateResolver;

        public ActiveUpdater(IVersionProvider currentVersionProvider, IVersionProvider serverVersionProvider, IUpdateResolver updateResolver){
            _currentVersionProvider = currentVersionProvider;
            _serverVersionProvider = serverVersionProvider;
            _updateResolver = updateResolver;
        }
        public Boolean UpdateSuccessful()
        {
            Version currentVersion = new Version( _currentVersionProvider.GetVersion());
            Version serverVersion = new Version(_serverVersionProvider.GetVersion());

            if (currentVersion.CompareTo(serverVersion) < 0)
            {
                return _updateResolver.ResolveUpdate();
            }
            else
            {
                return true;
            }
        }
    }
}
