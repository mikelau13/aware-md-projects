import axios from 'axios';


export default class UserSubmitUtility {
    protected apiPost = (url: string, postObj: any):Promise<any> => {
      const headers = {
        Accept: 'application/json'
      };
  
      return axios.post(url, postObj, { headers })
        .then(result => {
          return Promise.resolve(result.data);
        }).catch(error => {
          return Promise.reject(error);          
        });
    }

    protected apiPut = (url: string, postObj: any):Promise<any> => {
        const headers = {
            Accept: 'application/json'
        };

        return axios.put(url, postObj, { headers })
            .then(result => {
              return Promise.resolve(result.data);
            }).catch(error => {
              return Promise.reject(error);
        });
    }
	
    protected apiGet = (url: string, query_string: string):Promise<any> => {
        const headers = {
          contentType: 'application/json'
        };
    
        return axios.get(`${url}${query_string}`, { headers })
          .then(result => {
            return Promise.resolve(result.data);
          }).catch(error => {
            return Promise.reject(error);            
          });
    }

    protected apiDelete = (url: string, id: string):Promise<any> => {
        const headers = {
          contentType: 'application/json'
        };
    
        return axios.delete(`${url}${id}`, { headers })
          .then(result => {
            return Promise.resolve(result.data);
          }).catch(error => {
            return Promise.reject(error);            
          });
    }
}
