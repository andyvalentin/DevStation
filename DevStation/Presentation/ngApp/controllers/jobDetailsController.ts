namespace DevStation.Controllers {
    export class JobDetailsController {
        public job;

        constructor(private $http: ng.IHttpService, $routeParams, private $location: ng.ILocationService) {
            $http.get(`/api/jobs/${$routeParams["id"]}`)
                .then((response) => {
                    this.job = response.data;
            })
        }
    }
}