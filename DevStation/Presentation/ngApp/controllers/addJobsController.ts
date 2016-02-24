namespace DevStation.Controllers {
    export class AddJobsController {
        public job;


        public addJob() {
                this.$http.post(`/api/jobs/add`, this.job)
                    .then((response) => {
                        if (response.status == 400) {
                            alert("Description must be at least 25 characters");
                        } else {
                            location.reload();
                        }                                             
                    })
        }

        public logout() {
            this.$window.localStorage.removeItem('token');
        }

        constructor(private $http: ng.IHttpService, private $location: ng.ILocationService, private $window) {
            
        }
    }
}