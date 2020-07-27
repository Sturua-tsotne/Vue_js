<template>
  <div id="app" class="app">
    <div id="nav" class="nav">
      <!-- <router-link to="/">Home</router-link> | -->
      <div class="sidenav">
        <!-- :href="'/about/' + item.id" -->
        <a 
          v-for="item in  cabinets"
          :key="item.id"
          v-bind:class="{ 'active' : isSelected(item.id) } "
          v-on:click="selected = item.id "
          @click="getshelf"
        >კარადა {{item.num}}</a>

        <!-- -->
        
      </div>
      <div class="footermanue d-flex text-light align-items-center px-3 py-2">
          <b-button variant="outline-info" href="/addAll" >დამატება</b-button>
        </div>
    </div>
    <div class="main">
      <div class="about">
        <!-- v-on:click="openandclos(item.contactID)"  -->
        <div>
          <b-card
            class="cardNull"
            v-if="isNull"
            title="კარადა ცარიელია"
            body-class="text-center"
            header-tag="nav"
          ></b-card>
          <b-card
            class="maincard"
            v-on:click="clicked=item.id"
            v-for="item in  Shelfes"
            :key=" item.productid"
            :title="headerTitle + item.productid"
            sub-title
          >
            <b-card
              class="product"
              :title="item.product.name"
              :sub-title=" code + item.product.code"
            >
              <b-card-text class="text-right price">
                <h6 class="price">ფასი: {{item.product.price}}</h6>
                <h6>წონა : {{item.product.weight}} კგ</h6>
              </b-card-text>
            </b-card>
          </b-card>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      isNull: false,
      clicked: 1,
      id: null,
      code: "კოდი:  ",
      headerTitle: " თარო ",
      Shelfes: [],
      isActive: false,
      selected: 1,
      cabinets: [],
    };
  },
  methods: {
    isSelected(i) {
      return i === this.selected;
    },
    isclickedm(i) {
      return i === this.clicked;
    },
    getshelf() {
      (this.Shelfes = []),
        axios
          .get("http://localhost:64166/Home/Shelfes/" + this.selected)
          .then((response) => {
            console.log(response.data);
            if (response.data.length == 0) {
              this.isNull = true;
            } else {
              this.isNull = false;
            }

            for (var i = 0; i < response.data.length; i++) {
              this.Shelfes.push({
                productid: response.data[i].productId.toString(),
                product: response.data[i].product,
              });
            }
          })
          .catch((e) => {
            console.log(e);
          });
    },
  },
  created() {
    this.id = this.$route.params.id;
    // console.log(this.id);
    axios
      .get(`http://localhost:64166/Home/Cabinets`)
      .then((response) => {
        for (var i = 0; i < response.data.length; i++) {
          this.cabinets.push({
            id: response.data[i].id,
            num: response.data[i].num,
          });
        }
      })
      .catch((e) => {
        console.log(e);
      });
    this.Shelfes = [];
    axios
      .get("http://localhost:64166/Home/Shelfes/" + this.selected)
      .then((response) => {
        if (response.data.length == 0) {
          this.isNull = true;
        } else {
          this.isNull = false;
        }
        for (var i = 0; i < response.data.length; i++) {
          this.Shelfes.push({
            productid: response.data[i].productId.toString(),
            product: response.data[i].product,
          });
        }
      })
      .catch((e) => {
        console.log(e);
      });
  },
};
</script>



<style>
body {
  font-family: "Lato", sans-serif;
}
.cardNull {
  margin-top: 15%;
  box-shadow: 0 0 12px 0px #b828ac5e;
}
.footermanue {
  position: fixed;
    margin-top: 61%;
    margin-left: 141px;
    z-index: 99;
 
}
.outline-info{
 color:#1a2ff3f8!important; 
}
.active {
  color: #ffffff !important;
  background-color: #0019fbf8;
}
.product {
  color: #2204a7e3 !important;

  box-shadow: 0 0 9px #071ffb66;
}
.maincard {
  color: #071ffb5e;
  margin-top: 20px;
}
.sidenav {
  height: 100%;
  width: 260px;
  position: fixed;
  z-index: 1;
  top: 0;
  left: 0;
  background-color: rgb(226 220 220 / 6%);
  overflow-x: hidden;
  text-decoration: none;
  padding-top: 20px;
  box-shadow: 0 0 12px 0px #0011fbb2;
  text-align: center;
}
.price {
  margin-top: 20px;
  color: #0011fbb2;
}
.main {
  color: #2204a7e3;
}

.sidenav a {
  padding: 6px 8px 6px 16px;
  text-decoration: none !important;
  font-size: 18px;
  color: #dad6d6;
  display: block;
  margin-top: 5px;
  cursor: pointer;
}
.price {
  margin-right: 50px;
  margin-top: -50px;
}
.sidenav a:hover {
  color: #f1f1f1;
}

.main {
  margin-left: 265px; /* Same as the width of the sidenav */
  font-size: 28px; /* Increased text to enable scrolling */
  padding: 0px 10px;
}
.noclicked {
  display: none !important;
}
.clickedm {
  display: block !important;
}
@media screen and (max-height: 450px) {
  .sidenav {
    padding-top: 15px;
  }
  .sidenav a {
    font-size: 18px;
  }
}
</style>