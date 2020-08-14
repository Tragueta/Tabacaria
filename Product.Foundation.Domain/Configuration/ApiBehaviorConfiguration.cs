using Microsoft.Extensions.DependencyInjection;

namespace Product.Foundation.Domain.Configuration
{
    public static class ApiBehaviorConfiguration
    {
        public static IServiceCollection AdicionarInjecaoDependenciaInfra(this IServiceCollection services)
        {
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.AddTransient<ICelcoinServico, CelcoinServico>();
            //services.AddTransient<ICartaoServico, CartaoServico>();
            //services.AddTransient<IProdutoServico, ProdutoServico>();
            //services.AddTransient<IIFlexServico, IFlexServico>();
            //services.AddTransient<ITicketPlusPagamentoServico, TicketPlusPagamentoServico>();
            //services.AddTransient<ITransferenciaBancariaFavoritosRepositorio, FavoritoTransferenciaBancariaRepositorio>();

            return services;
        }
    }
}
