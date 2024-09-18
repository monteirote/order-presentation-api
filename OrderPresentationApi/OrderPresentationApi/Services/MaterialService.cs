using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPresentationApi.Repositories
{
    public interface IMaterialService {

    }

    public class MaterialService : IMaterialService {

        private readonly IMaterialRepository _clienteRepository;

        public MaterialService (IClienteRepository clienteRepository) {
            _clienteRepository = clienteRepository;
        }
    }
}
