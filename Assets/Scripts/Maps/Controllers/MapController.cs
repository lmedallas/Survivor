using Maps.Views;

namespace Maps.Controllers
{
    public class MapController : IMapController
    {
        private IMapView _MapView;
        public MapController(IMapView mapView)
        {
            _MapView = mapView;
        }

    }
}
